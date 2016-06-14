using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoraviaTraning.Web.Models.Catalogs
{
    public class CartMannager
    {
        public CartMannager() { }
        public CartMannager(ApplicationDbContext db) { this.db = db; }


        private ApplicationDbContext db;


        public Cart CreateCart(string userId)
        {
            var user = db.Users.Find(userId);

            Cart cart = new Cart();
            cart.CreationDate = DateTime.Now;
            cart.Id = Guid.NewGuid().ToString();
            cart.User = user;

            db.Carts.Add(cart);
            db.SaveChanges();

            return cart;
        }

        public void AddProductToCart(Product prod, Cart cart)
        {
            if(cart.Items == null)
            {
                CartItem newItem = new CartItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Product = prod,
                    Qty = 1
                };
                cart.Items.Add(newItem);
            }
            else
            {
                var item = cart.Items.Where(i => i.Product.Id == prod.Id).FirstOrDefault();
                if (item == null)
                {
                    CartItem newItem = new CartItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        Product = prod,
                        Qty = 1
                    };
                    cart.Items.Add(newItem);
                }
                else
                {
                    item.Qty++;
                }
            }
            



            return;
        }
    }
}