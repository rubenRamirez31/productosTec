using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EjercicioEFC.Models;
using Microsoft.EntityFrameworkCore;

namespace productosTec.Controllers
{
    public class ConstruccionesController : Controller
    {

        private readonly ConstruccionesContext db;

        public ConstruccionesController(ConstruccionesContext db)
        {
            this.db = db;
        }

        public IActionResult Principal() {
            var construcciones = db.Construcciones
            .ToList();
            return View(construcciones);
        }

        [HttpGet]
        public IActionResult AgregarConstruccion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarConstruccion(Construccione c)
        {
            db.Construcciones.Add(c);
            db.SaveChanges();
            return RedirectToAction("Principal");
        }
        
    }
}