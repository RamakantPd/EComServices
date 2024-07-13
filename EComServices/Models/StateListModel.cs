
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class StateListModel
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string State_Name { get; set; } = string.Empty;
    }
}
