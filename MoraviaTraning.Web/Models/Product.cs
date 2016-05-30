using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoraviaTraning.Web.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

    }
}