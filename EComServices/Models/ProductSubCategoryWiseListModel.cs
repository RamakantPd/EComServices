using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class ProductSubCategoryWiseListModel
    {
        [Key]
        public int PSCWId { get; set; }
        [Required(ErrorMessage ="Please Select Product Category")]
        [Column(TypeName ="Int")]
        [DisplayName("Category")]
        public int ProductWiseCategory { get; set; }
        [Required(ErrorMessage ="Please Enter Product Name")]
        [Column(TypeName ="Varchar(100)")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Please Enter Price for the Product")]
        [Column(TypeName ="Decimal(18,2)")]
        [DisplayName("Product Price")]
        public float P_Price { get; set; }
        [Required(ErrorMessage = "Please Enter Product Description")]
        [Column(TypeName = "Varchar(200)")]
        [DisplayName("Description")]
        public string P_Description { get; set; } = string.Empty;
        [Column(TypeName ="Varchar(400)")]
        [DisplayName("Product Image Name")]
        public string? P_Image_Name { get; set; }
        [NotMapped]
        public IFormFile? Image_Upload { get; set; }
        [NotMapped]
        public List<ProductCategoryModel>? CategoryList { get; set; }
    }
}
