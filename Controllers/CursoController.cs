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


        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;

        }
    }
}