using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class CountryListModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please Enter Country Name!")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Country Name")]
        public string Country_Name { get; set; } = string.Empty;
    }
}
