using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoraviaTraning.Web.Models
{
    public class CartItem
    {
        [Key]
        public string Id { get; set; }
        public int Qty { get; set; } = 0;

        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }

    }
}