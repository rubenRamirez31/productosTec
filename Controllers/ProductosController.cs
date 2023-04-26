using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EjercicioEFC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjercicioEFC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly BdpersonasContext db;

        public ProductosController(BdpersonasContext db)
        {
            this.db = db;
        }

        public IActionResult Principal() {
            var productos = db.Productos
            .Include(x => x.IdCategoriaNavigation)
            .ToList();
            return View(productos);
        }

        [HttpGet]
        public IActionResult AgregarProducto() {
           ViewBag.IdCategoria = new SelectList(db.Categorias,"Id","NombreCategoria");
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(Producto p) 
        {
            db.Productos.Add(p);
            db.SaveChanges();
            return RedirectToAction("Principal");
        }

        [HttpGet]
        public IActionResult EliminarProducto (SByte? id){
            if (id == null)
            {
                return NotFound();
            }
            Producto p = db.Productos.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpPost]
        public IActionResult ProductoEliminado(SByte? id){
            Producto p = db.Productos.Find(id);
            db.Productos.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Principal");
        }

    }
}