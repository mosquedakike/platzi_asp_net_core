﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                             where asig.Id == asignaturaId
                             select asig;
            return View(asignatura.FirstOrDefault());
            }
            else
            {
                return View("MultiAsignatura", _context.Asignaturas);
            }
        }

        public IActionResult MultiAsignatura()
        {
            ViewBag.CosaDinamica = "DEVELOPER";
            ViewBag.Fecha = DateTime.UtcNow;

            return View("MultiAsignatura", _context.Asignaturas);
        }

        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;

        }
    }
}