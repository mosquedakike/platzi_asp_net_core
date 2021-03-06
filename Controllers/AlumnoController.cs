﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AlumnoController : Controller
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
                var alumno = from alum in _context.Alumnos
                             where alum.Id == id
                             select alum;
            return View(alumno.FirstOrDefault());
            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }
        }

        public IActionResult MultiAlumno()
        {

        ViewBag.CosaDinamica = "DEVELOPER";
        ViewBag.Fecha = DateTime.UtcNow;

        return View("MultiAlumno", _context.Alumnos);
        }


        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
        {
            _context = context;

        }
    }
}