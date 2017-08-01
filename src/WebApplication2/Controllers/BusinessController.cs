using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YellowPage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YellowPage.Controllers
{
    public class BusinessController : Controller
    {
        private YellowPageContext db = new YellowPageContext();
        //View list of businesses
        public IActionResult Index()
        {
            return View(db.businesses.Include(business => business.Category).ToList());
        }
        //View business details
        public IActionResult Details(int id)
        {
            var thisBusiness = db.businesses.FirstOrDefault(something => something.id == id);
            return View(thisBusiness);
        }
        //create new business
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.types, "CategoryId", "description");
            return View();
        }
        [HttpPost]
        public IActionResult Create (Shop busi)
        {
            db.businesses.Add(busi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //edit business
        public IActionResult Edit(int id)
        {
            var thisBusiness = db.businesses.FirstOrDefault(something => something.id == id);
            ViewBag.CategoryId = new SelectList(db.types, "CategoryId", "description");
            return View(thisBusiness);
        }
        [HttpPost]
        public IActionResult Edit(Shop busi)
        {
            db.Entry(busi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //delete business
        public ActionResult Delete(int id)
        {
            var thisBusiness = db.businesses.FirstOrDefault(something => something.id == id);
            return View(thisBusiness);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisBusiness = db.businesses.FirstOrDefault(something => something.id == id);
            db.businesses.Remove(thisBusiness);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
