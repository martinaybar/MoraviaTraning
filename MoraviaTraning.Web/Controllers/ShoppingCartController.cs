﻿using MoraviaTraning.Web.Models;
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
            return PartialView("_ProductList");
        }


        #region Angular

        public JsonResult GetProducts()
        {
            var products = db.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NewShoppingCart()
        {
            return View();
        }

        public ActionResult Product()
        {
            return PartialView("_Product");
        }

        public ActionResult ShoppingCart()
        {
            return PartialView("_ShoppingCart");
        }

        public ActionResult Store()
        {
            return PartialView("_Store");
        }



        #endregion



    }
}