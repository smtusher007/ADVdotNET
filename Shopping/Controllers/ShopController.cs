using Shopping.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shopping.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var db = new ECommerceEntities();
            var product = db.Products.ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            var db = new ECommerceEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCart(int Id)
        {
            var db = new ECommerceEntities();
            var product = (from p in db.Products where p.Id == Id select p).SingleOrDefault();
            if (Session["cart"]==null)
            {
                List<Product>products=new List<Product> ();
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(product);
                Session["cart"]=json;
            }
            else
            {
                var cart = Session["cart"].ToString();
                var p = new JavaScriptSerializer().Deserialize<List<Product>>(cart);
                p.Add(product);
                string json = new JavaScriptSerializer().Serialize(p);
                Session["cart"] = json;
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveCart()
        {
            return View();
        }
    }
}