using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace EComServices.Models
{
    public class ProductCategoryModel
    {
        [Key]
        public int PId { get; set; }
        [Required(ErrorMessage ="Please Select Category!")]
        [Column(TypeName ="INT")]
        [DisplayName("Category Type")]
        public int Prod_CateId { get; set; }
        [Required(ErrorMessage ="Please Enter Product Name")]
        [StringLength(40)]
        [Column(TypeName ="Varchar(100)")]
        [DisplayName("Category Name")]
        public string P_Category { get; set; } = string.Empty;
        [Column(TypeName ="varchar(100)")]
        [DisplayName("Select Image for Category")]
        public string? Image_Name { get; set; }
        [NotMapped]
        [DisplayName("Image Upload")]
        public IFormFile? Image_Upload { get; set; }
        [NotMapped]
        public List<ProductModel>? ProductList { get; set; }
    }
}
