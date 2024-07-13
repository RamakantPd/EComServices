using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class UserRegistrationModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("First Name")]
        public string First_Name { get; set; } = string.Empty;
        public string Middle_Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Last Name")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Last Name")]
        public string Last_Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Contact No")]
        [Column(TypeName = "int")]
        [DisplayName("Contact")]
        public int Contact_No { get; set; }



        [Required(ErrorMessage = "Please Select Country!")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Country")]
        public string CountryCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Mail Id")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("User Id")]
        [DataType(DataType.EmailAddress)]
        public string Email_Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Password")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Password")]
        [StringLength(100, MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string? Salt { get; set; }
        [Required(ErrorMessage = "Please Select State!")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("State")]
        public string StateCode { get; set; } = string.Empty;

        // public List<UserRegistrationModel> UserRegis { get; set; }
        [NotMapped]
        public List<StateListModel>? StatList { get; set; } 
        [NotMapped]
        public List<CountryListModel>? Countrylist { get; set; }
        [NotMapped]
        public List<UserLogin>? Userlogin { get; }
    }
}
