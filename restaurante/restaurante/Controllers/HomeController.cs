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

            using (Models.DbModel db= new Models.DbModel())
            {
                List<TablaViewModel> lst=
                    (from d in db.detalle_orden   
                    select new TablaViewModel
                    {

                        id_detalle=d.id_detalle,
                        id_producto=d.id_producto,
                    }).ToList();
             }

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
    }
}