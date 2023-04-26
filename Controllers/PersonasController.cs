using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EjercicioEFC.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioEFC.Controllers
{

    public class PersonaController : Controller
    {
        private readonly BdpersonasContext db;

        public PersonaController(BdpersonasContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Persona p)
        {
            db.Personas.Add(p);
            db.SaveChanges();
            return RedirectToAction("Principal");
        }

        [HttpGet]
        public IActionResult Principal()
        {
            return View(db.Personas.ToList());
        }

        [HttpGet]
        public IActionResult Actualizar(int? id)
        {
            if (id == null)
                return NotFound();
            Persona p = db.Personas.Find(id);
            if (p == null)
                return NotFound();
            return View(p);
        }

        [HttpPost]
        public IActionResult Actualizar (Persona p){
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Principal");
        }

        [HttpGet]
        public IActionResult Eliminar (int? id){
            if (id == null)
            {
                return NotFound();
            }
            Persona p = db.Personas.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpPost]
        public IActionResult Eliminado(int? id){
            Persona p = db.Personas.Find(id);
            db.Personas.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Principal");
        }

        [HttpGet]
        public IActionResult Pruebas() {
            var personas = db.Personas
            .ToList();
            return View(personas);
        }

        [HttpPost]
        public IActionResult Pruebas(String ocupacion){
            var personas = db.Personas.
            Where(x => x.Ocupacion == ocupacion).ToList();
            return View(personas);
        }

    }
}