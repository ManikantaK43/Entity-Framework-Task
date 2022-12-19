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
    public class DimProductsController : Controller
    {
        private AdventureWorksDW2019Entities1 db = new AdventureWorksDW2019Entities1();

        // GET: DimProducts
        public ActionResult Index()
        {
            var dimProducts = db.DimProducts.Include(d => d.DimProductSubcategory);
            return View(dimProducts.ToList());
        }

        // GET: DimProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProduct dimProduct = db.DimProducts.Find(id);
            if (dimProduct == null)
            {
                return HttpNotFound();
            }
            return View(dimProduct);
        }

        // GET: DimProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductSubcategoryKey = new SelectList(db.DimProductSubcategories, "ProductSubcategoryKey", "EnglishProductSubcategoryName");
            return View();
        }

        // POST: DimProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductKey,ProductAlternateKey,ProductSubcategoryKey,WeightUnitMeasureCode,SizeUnitMeasureCode,EnglishProductName,SpanishProductName,FrenchProductName,StandardCost,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,ListPrice,Size,SizeRange,Weight,DaysToManufacture,ProductLine,DealerPrice,Class,Style,ModelName,LargePhoto,EnglishDescription,FrenchDescription,ChineseDescription,ArabicDescription,HebrewDescription,ThaiDescription,GermanDescription,JapaneseDescription,TurkishDescription,StartDate,EndDate,Status")] DimProduct dimProduct)
        {
            if (ModelState.IsValid)
            {
                db.DimProducts.Add(dimProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductSubcategoryKey = new SelectList(db.DimProductSubcategories, "ProductSubcategoryKey", "EnglishProductSubcategoryName", dimProduct.ProductSubcategoryKey);
            return View(dimProduct);
        }

        // GET: DimProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProduct dimProduct = db.DimProducts.Find(id);
            if (dimProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSubcategoryKey = new SelectList(db.DimProductSubcategories, "ProductSubcategoryKey", "EnglishProductSubcategoryName", dimProduct.ProductSubcategoryKey);
            return View(dimProduct);
        }

        // POST: DimProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductKey,ProductAlternateKey,ProductSubcategoryKey,WeightUnitMeasureCode,SizeUnitMeasureCode,EnglishProductName,SpanishProductName,FrenchProductName,StandardCost,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,ListPrice,Size,SizeRange,Weight,DaysToManufacture,ProductLine,DealerPrice,Class,Style,ModelName,LargePhoto,EnglishDescription,FrenchDescription,ChineseDescription,ArabicDescription,HebrewDescription,ThaiDescription,GermanDescription,JapaneseDescription,TurkishDescription,StartDate,EndDate,Status")] DimProduct dimProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductSubcategoryKey = new SelectList(db.DimProductSubcategories, "ProductSubcategoryKey", "EnglishProductSubcategoryName", dimProduct.ProductSubcategoryKey);
            return View(dimProduct);
        }

        // GET: DimProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProduct dimProduct = db.DimProducts.Find(id);
            if (dimProduct == null)
            {
                return HttpNotFound();
            }
            return View(dimProduct);
        }

        // POST: DimProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DimProduct dimProduct = db.DimProducts.Find(id);
            db.DimProducts.Remove(dimProduct);
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
