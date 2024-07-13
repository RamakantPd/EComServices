using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class AddProduct
    {
        public int ProductId { get; set; }
        public string? ProductType { get; set; } 
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string? Product_Name { get; set; }

    }
}
