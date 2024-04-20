using restaurante.Models;
using restaurante.Models.ViewModels;
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
        public ActionResult Create(int id_orden)
        {
            // Puedes utilizar el id_orden como necesites, por ejemplo, pasándolo a la vista
            ViewBag.id_orden = id_orden;

            List<TablaViewModel> lst = null;
            using (Models.DbModel db = new Models.DbModel())
            {
                lst = (from d in db.producto
                       select new TablaViewModel
                       {

                           id_detalle = d.id_producto,
                           id_producto = d.nombre,


                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.id_producto.ToString(),
                    Value = d.id_detalle.ToString(),
                    Selected = false
                };
            });


            ViewBag.items = items;



            // Aquí puedes realizar cualquier otra lógica necesaria antes de mostrar la vista de creación
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
