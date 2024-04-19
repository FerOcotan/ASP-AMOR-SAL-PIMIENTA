using restaurante.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restaurante.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Detalle
        public ActionResult Index()
        {
            using (DbModel context = new DbModel())
            {

                var detallesOrden = context.detalle_orden.Include(d => d.producto)
                                                         .Include(d => d.orden)
                                                         .ToList();
                return View(detallesOrden);
            }
        }

        public ActionResult Kitchen()
        {
            using (DbModel context = new DbModel())
            {

                var detallesOrden = context.detalle_orden.Include(d => d.producto)
                                                         .Include(d => d.orden)
                                                         .ToList();
                return View(detallesOrden);
            }
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.detalle_orden.Where(x => x.id_detalle == id).FirstOrDefault());

            }
        }

        // GET: Detalle/Create
        public ActionResult Create()
        {
            /*using (DbModel context = new DbModel()) 
            {
                // Ajusta "Nombre" según el campo que quieres mostrar
                ViewBag.id_orden = new SelectList(context.orden, "id_orden", "Nombre");

                // Ajusta "NombreProducto" según el campo que quieres mostrar
                ViewBag.id_producto = new SelectList(context.producto, "id_producto", "NombreProducto"); 
                return View();
            }*/

            return View();
         
        }

        // POST: Detalle/Create
        [HttpPost]
        public ActionResult Create(detalle_orden detalle_orden)
        {
            try
            {
                // TODO: Add insert logic here
                using (DbModel context = new DbModel())
                {
                    context.detalle_orden.Add(detalle_orden);
                    context.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditKitchen(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.detalle_orden.Where(x => x.id_detalle == id).FirstOrDefault());

            }
        }

        [HttpPost]
        public ActionResult EditKitchen(int id, detalle_orden detalle_orden)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModel context = new DbModel())
                {
                    context.Entry(detalle_orden).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        // GET: Detalle/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.detalle_orden.Where(x => x.id_detalle == id).FirstOrDefault());

            }
        }

        // POST: Detalle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, detalle_orden detalle_orden)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModel context = new DbModel())
                {
                    context.Entry(detalle_orden).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Detalle/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.detalle_orden.Where(x => x.id_detalle == id).FirstOrDefault());

            }
        }

        // POST: Detalle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModel context = new DbModel())
                {
                    detalle_orden detalle_orden = context.detalle_orden.Where(x => x.id_detalle == id).FirstOrDefault();
                    context.detalle_orden.Remove(detalle_orden);
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
