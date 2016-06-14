using MoraviaTraning.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoraviaTraning.Web.Controllers
{
    public class ShoppingCartController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingCart
        public ActionResult Products()
        {
            return View();
        }


        #region Angular

        public JsonResult GetProducts()
        {
            var products = db.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        #endregion



    }
}