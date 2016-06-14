using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoraviaTraning.Web.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }

    public enum RolesEnum
    {
        Client = 1,
        Admin = 2,
        WebAdmin = 3
    }
}