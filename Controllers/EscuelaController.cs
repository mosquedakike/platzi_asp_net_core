﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            
            ViewBag.CosaDinamica = "DEVELOPER";
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }

        private EscuelaContext _context;

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
            
        }
    }
}