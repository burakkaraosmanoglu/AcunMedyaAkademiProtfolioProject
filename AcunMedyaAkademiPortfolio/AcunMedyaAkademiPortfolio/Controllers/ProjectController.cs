using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolio.Models;

namespace AcunMedyaAkademiPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        DBDominicPortfolioEntities db = new DBDominicPortfolioEntities();
        public ActionResult ProjectList()
        {
            var values=db.TblProject.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject() 
        {
            List<SelectListItem> values=(from x in db.TblCategory.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.CategoryName,
                                             Value=x.Categoryid.ToString()
                                         }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }
        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProject.Find(id);
            db.TblProject.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ProjectList");

        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            List<SelectListItem> values1 = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.Categoryid.ToString()
                                           }).ToList();
            ViewBag.v = values1;
            var values = db.TblProject.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProject.Find(p.Projectid);
            values.Description = p.Description;
            values.İmageUrl = p.İmageUrl;
            values.Categoryid = p.Categoryid;
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }



    }
}