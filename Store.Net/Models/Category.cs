using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Net.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category name")]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Category image link")]
        public string ImgLink { get; set; }
    }
}