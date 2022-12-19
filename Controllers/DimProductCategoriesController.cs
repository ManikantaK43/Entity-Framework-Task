using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrame.Models;

namespace EntityFrame.Controllers
{
    public class DimProductCategoriesController : Controller
    {
        private AdventureWorksDW2019Entities1 db = new AdventureWorksDW2019Entities1();

        // GET: DimProductCategories
        public ActionResult Index()
        {
            return View(db.DimProductCategories.ToList());
        }

        // GET: DimProductCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            if (dimProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(dimProductCategory);
        }

        // GET: DimProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DimProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCategoryKey,ProductCategoryAlternateKey,EnglishProductCategoryName,SpanishProductCategoryName,FrenchProductCategoryName")] DimProductCategory dimProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.DimProductCategories.Add(dimProductCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dimProductCategory);
        }

        // GET: DimProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            if (dimProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(dimProductCategory);
        }

        // POST: DimProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCategoryKey,ProductCategoryAlternateKey,EnglishProductCategoryName,SpanishProductCategoryName,FrenchProductCategoryName")] DimProductCategory dimProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimProductCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimProductCategory);
        }

        // GET: DimProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            if (dimProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(dimProductCategory);
        }

        // POST: DimProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            db.DimProductCategories.Remove(dimProductCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
