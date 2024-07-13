using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class ProductModel
    {
        [Key]
        public int ProdId { get; set; }
        [Required(ErrorMessage ="Please Enter Product Name")]
        [Column(TypeName ="Varchar(100)")]
        [DisplayName("Product Name")]
        public string Product_Name { get; set; } = string.Empty;
    }
}
