using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        DBDominicPortfolioEntities db = new DBDominicPortfolioEntities();
        public ActionResult TestimonialList()
        {
            var values= db.TblTestimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial p)
        {
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(values);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");

        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            var values = db.TblTestimonial.Find(p.TestimonialID);
            values.Title = p.Title;
            values.Description = p.Description;
            values.NameSurname = p.NameSurname;
            values.ImageUrl = p.ImageUrl;
            values.Job = p.Job;
            values.Status = p.Status;
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}