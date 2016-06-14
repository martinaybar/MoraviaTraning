using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoraviaTraning.Web.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using MoraviaTraning.Web.Models.Catalogs;



namespace MoraviaTraning.Web.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //TODO Agregar DI o un repo
        //private CartMannager cartMannager = new CartMannager(db);

        #region ShoppingCart

        // GET: Carts/SelectProducts
        public async Task<ActionResult> SelectProducts()
        {
            //var userId = User.Identity.GetUserId();
            //var products = db.Products.ToList();
            //this.Session["ProductList"] = products;
            //ViewBag.Products = Session["ProductList"];

            return View(await db.Products.ToListAsync());
        }

        public ActionResult AddProduct(string id)
        {
            //Cart Mannager
            CartMannager cartMannager = new CartMannager(db);

            Product prod = db.Products.Find(id);
            Cart cart = (Cart)this.Session[GeneralData.CartSession];

            if (cart == null)
            {
                //Create new Cart
                string userId = User.Identity.GetUserId();
                cart = cartMannager.CreateCart(userId);
            }

            cartMannager.AddProductToCart(prod, cart);

            this.Session[GeneralData.CartSession] = cart;

            return RedirectToAction("SelectProducts");
        }

        #endregion


        // GET: Carts
        public async Task<ActionResult> Index()
        {
            return View(await db.Carts.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            //var userId = User.Identity.GetUserId();

            //Cart cart = new Cart();
            //cart.User = db.Users.Find(userId);
            //cart.Id = Guid.NewGuid().ToString();
            //cart.Total = 100;
            //var products = db.Products.ToList();
            //this.Session["ProductList"] = products;
            //ViewBag.Products = Session["ProductList"];


            return View();
        }


       

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SubTotal,Total,Discount,CreationDate,Address")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SubTotal,Total,Discount,CreationDate,Address")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
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
