using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class AboutController : Controller
    {
        DBDominicPortfolioEntities db = new DBDominicPortfolioEntities();
        public ActionResult AboutList()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(TblAbout p)
        {
            db.TblAbout.Add(p);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            db.TblAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("AboutList");

        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var values = db.TblAbout.Find(p.AboutID);
            values.Title = p.Title;
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;

            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}