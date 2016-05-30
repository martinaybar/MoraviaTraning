using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoraviaTraning.Web.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public float SubTotal { get; set; }
        public float Total { get; set; }
        public float Discount { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }


    }
}