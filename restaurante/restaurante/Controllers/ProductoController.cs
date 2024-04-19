using restaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restaurante.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (DbModel context = new DbModel()) 
            {

                return View(context.producto.ToList());
            }
               
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel context = new DbModel()) 
            {
                return View(context.producto.Where(x=> x.id_producto == id).FirstOrDefault());
            }
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        //Aca se crea un nuevo elemento para la tabla producto.
        public ActionResult Create(producto producto)
        {
            try
            {
                // TODO: Add insert logic here
                using (DbModel context = new DbModel()) 
                {
                    context.producto.Add(producto);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.producto.Where(x => x.id_producto == id).FirstOrDefault());
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, producto producto)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModel context = new DbModel()) 
                {
                    context.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.producto.Where(x => x.id_producto == id).FirstOrDefault());
            }
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModel context = new DbModel()) 
                {
                    producto producto = context.producto.Where(x => x.id_producto == id).FirstOrDefault();
                    context.producto.Remove(producto);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
