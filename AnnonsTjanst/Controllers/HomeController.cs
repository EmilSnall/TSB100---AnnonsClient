using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnonsTjanst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            return View(client.HamtaAllaAnnonser());
        }

        public ActionResult About()
        {
            //List<Annons> HamtaKopAnnonser(int ProfilID)
            //List<Annons> HamtaSaljAnnonser(int ProfilID)
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            return View(client.HamtaSaljAnnonser(1337));
            //return View(client.HamtaKopAnnonser(1));
            
            //return View();
                }

        public ActionResult Contact()
        {

            //Annons HamtaAnnons(int AnnonsID)
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            var temp = client.HamtaAnnons(1);
            return View(temp);
            //return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Create(ServiceReference1.Annonser annons)
        {
            ViewBag.Message = "Your contact page.";
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string result = client.SkapaAnnons(annons);
            ViewBag.Message = result;
            return RedirectToAction("Index");
        }
    }
}