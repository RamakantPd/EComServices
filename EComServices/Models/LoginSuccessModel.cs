using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class LoginSuccessModel
    {
        
            [Key]
            public int id { get; set; }
            public string? FileName { get; set; }
        public string? UserId { get; set; }
        [NotMapped]
        public List<ProductSubCategoryWiseListModel>? allprod { get; set; }
    }
}
