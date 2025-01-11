using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class ServicesController : Controller
    {
        DBDominicPortfolioEntities db = new DBDominicPortfolioEntities();
        public ActionResult ServicesList()
        {
            var values = db.TblService.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("ServicesList");
        }
        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ServicesList");

        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblService.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var values = db.TblService.Find(p.ServiceID);
            values.Title = p.Title;
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;

            db.SaveChanges();
            return RedirectToAction("ServicesList");
        }
    }
}