using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class UserLogin
    {
        [Key]
        public int Empid { get; set; }
        [Required(ErrorMessage = "Please Enter Mail Id")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("User Id")]
        [DataType(DataType.EmailAddress)]
        public string Email_id { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Password")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
