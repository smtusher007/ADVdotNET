using ECommereceSite.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommereceSite.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult Index()
        {
            var db = new ShoppingEntities();
            return View(db.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            var db = new ShoppingEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new ShoppingEntities();
            return View(db.Products.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var db = new ShoppingEntities();
            db.Products.AddOrUpdate(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var db = new ShoppingEntities();
            var products = db.Products.Find(Id);
            return View(products);
        }
        public ActionResult Delete(int Id)
        {
            var db = new ShoppingEntities();
            var products = db.Products.Find(Id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Porduct()
        {
            var db = new ShoppingEntities();
            return View(db.Products.ToList());  
        }

    }
}