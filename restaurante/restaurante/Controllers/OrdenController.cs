using restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restaurante.Controllers
{
    public class OrdenController : Controller
    {
        // GET: Orden
        public ActionResult Index()
        {
            using (DbModel context = new DbModel())
            {

                return View(context.orden.ToList());
            }
        }

        // GET: Orden/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel context = new DbModel()) 
            {
                return View(context.orden.Where(x=>x.id_orden == id).FirstOrDefault());

            }
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orden/Create
        [HttpPost]
        public ActionResult Create(orden orden)
        {
            try
            {
                // TODO: Add insert logic here
                using (DbModel context = new DbModel()) 
                {
                    context.orden.Add(orden);
                    context.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.orden.Where(x => x.id_orden == id).FirstOrDefault());

            }
        }

        // POST: Orden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, orden orden)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModel context = new DbModel()) 
                {
                    context.Entry(orden).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.orden.Where(x => x.id_orden == id).FirstOrDefault());

            }
        }

        // POST: Orden/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModel context = new DbModel()) 
                {
                    orden orden = context.orden.Where(x => x.id_orden == id).FirstOrDefault();
                    context.orden.Remove(orden);
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
