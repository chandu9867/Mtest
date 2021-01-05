using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mtest.Models;
using System.Data.Entity;

namespace Mtest.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public nimapEntities db = new nimapEntities();
        public ActionResult Index()
        {
            IEnumerable<Tbl_Details> e = db.Tbl_Details.ToList();
           
            return View(e);
        }

        public ActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include ="TempID,Product_ID,Product_Name,Category_ID,Category_Name")] Tbl_Details cus)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Details.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(cus);
        }


        public ActionResult Edit(int? TempID)
        {
            Tbl_Details cus = db.Tbl_Details.Find(TempID);
            return View(cus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TempID,Product_ID,Product_Name,Category_ID,Category_Name")] Tbl_Details cus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cus).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cus);
        }
        public ActionResult Delete(int? TempID)
        {
            Tbl_Details cus = db.Tbl_Details.Find(TempID);
            return View(cus);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int TempID)
        {
                Tbl_Details cus = db.Tbl_Details.Find(TempID);
                db.Tbl_Details.Remove(cus);
                db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}