using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class SearchItems
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Item Name")]
        public string ItemName { get; set; } = string.Empty;
    }
}
