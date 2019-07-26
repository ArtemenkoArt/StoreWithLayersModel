using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class CategoryDL
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImgLink { get; set; }
    }
}
