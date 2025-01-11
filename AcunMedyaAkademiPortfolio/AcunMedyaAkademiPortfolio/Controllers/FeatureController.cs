using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        DBDominicPortfolioEntities db = new DBDominicPortfolioEntities();
        public ActionResult FeatureList()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFeature(TblFeature p)
        {
            db.TblFeature.Add(p);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
        public ActionResult DeleteFeature(int id)
        {
            var values = db.TblFeature.Find(id);
            db.TblFeature.Remove(values);
            db.SaveChanges();
            return RedirectToAction("FeatureList");

        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = db.TblFeature.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)
        {
            var values = db.TblFeature.Find(p.FeatureID);
            values.NameSurname = p.NameSurname;
            values.Description = p.Description;
            values.ProjectName = p.ProjectName;
            values.ImageUrl = p.ImageUrl;

            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}