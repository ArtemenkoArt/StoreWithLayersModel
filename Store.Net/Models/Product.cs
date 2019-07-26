using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Net.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [StringLength(500)]
        [Display(Name = "Product image link")]
        public string ImgLink { get; set; }
    }
}