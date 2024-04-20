using restaurante.Models;
using restaurante.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restaurante.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            /*using (DbModel context = new DbModel())
            {
                List<TablaViewModel> lst=
                    (from d in context.detalle_orden   
                    select new TablaViewModel
                    {

                        id_detalle=d.id_detalle,
                        id_producto=d.id_producto,
                    }).ToList();
             }
            */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "UsuarioLogin");
        }
    }
}