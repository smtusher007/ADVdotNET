using ECommereceSite.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        public ActionResult Cart()
        {
            string json = (string)Session["products"];
            if (json == null)
            {
                return View();
            }
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            return View(products);
        }
        public ActionResult AddToCart(int Id)
        {
            var db = new ShoppingEntities();
            var product = (from b in db.Products
                           where b.Id == Id
                           select b).SingleOrDefault();
            if (Session["products"] == null)
            {
                List<Product> products = new List<Product>();
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["products"] = json;

            }
            else
            {
                string json = (string)Session["products"];
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                products.Add(product);
                json = new JavaScriptSerializer().Serialize(products);
                Session["products"] = json;

            }
            return RedirectToAction("Cart");
        }
        public ActionResult Order()
        {
            var db = new ShoppingEntities();
            var oder = db.Orders.ToList();
            return View(oder);

        }

        public ActionResult OrderDetails(int Id)
        {
            var db = new ShoppingEntities();
            var oder_details = (from b in db.OrderDetails
                                where b.OrderId == Id
                                select b).ToList();
            return View(oder_details);

        }
        public ActionResult CheckOut()
        {
            var db = new ShoppingEntities();
            string json = (string)Session["products"];
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            double totle_price = 0.0;
            foreach (var product in products)
            {
                totle_price += product.Price;
            }
            var order = new Order()
            {
                Price = (int)totle_price
            };
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (var product in products)
            {
                var order_details = new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = product.Id
                };
                db.OrderDetails.Add(order_details);
                db.SaveChanges();
            }
            Session.Remove("products");


            return RedirectToAction("Order", order.Id);
        }

    }
}