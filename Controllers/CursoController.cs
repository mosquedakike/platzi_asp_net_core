using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class CursoController : Controller
    {
        /*
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{alumnoId}")]
        public IActionResult Index(string alumnoId)
        {
            if (!string.IsNullOrWhiteSpace(alumnoId))
            {
                var alumno = from alum in _context.Asignaturas
                             where alum.Id == alumnoId
                             select alum;
            return View(alumno.FirstOrDefault());
            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }
        }*/
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var curso = from cur in _context.Cursos
                            where cur.Id == id
                            select cur;
                return View(curso.FirstOrDefault());
            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }
        }

        public IActionResult MultiCurso()
        {

            ViewBag.CosaDinamica = "DEVELOPER";
            ViewBag.Fecha = DateTime.UtcNow;

            return View("MultiCurso", _context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }
/*
        [HttpPut]
        public IActionResult Update(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Cursos.Update(curso);
                _context.SaveChanges();
                ViewBag.MensajeCrecion = "Curso Actualizado";
                return View();
            }
            else
            {
                return View(curso);
            }
        }
*/

[Route("Curso/Update")]
        [Route("Curso/Update/{cursoId}")]
        public IActionResult Update(string cursoId)
        {
            var cursoResponse = from curso in _context.Cursos
                where curso.Id == cursoId
                select curso;

            // validation: cursoId is available
            if (string.IsNullOrWhiteSpace(cursoId)) return MultiCurso();
            
            return View(cursoResponse.SingleOrDefault());
        }


        [Route("Curso/Update/{cursoId}")]
        [HttpPost]
        public IActionResult UpdatePost(string cursoId, Curso cursoForm)
        {   
            var curso = _context.Cursos.Find(cursoId);
            
            // validating all required data
            if (!ModelState.IsValid) return View("Update", curso);

            // search and extract the course to be updated
            // from db
            var modelCurso = _context.Cursos
                .SingleOrDefault(c => c.Id == cursoId);
            
            // updating fields
            // in case curso does not exist
            if (modelCurso == null) return MultiCurso();

            modelCurso.Nombre = cursoForm.Nombre;
            modelCurso.Dirección = cursoForm.Dirección;
            modelCurso.Jornada = cursoForm.Jornada;
            
            // saving updated data
            _context.SaveChanges();
            
            ViewBag.MensajeExtra = "Curso Actualizado con éxito!";
            
            // return to individual view(Note: Not method Index,
            // Index view instead)
            // add the course searched
            return View("Index",curso);
        }

        public IActionResult Test()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;

        }
    }
}