using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Models
{
    public class AddedItemsIntoCartForLoggedUser
    {
        [Key]
        public int ProductSrNo { get; set; }
        [Column(TypeName ="Int")]
        [DisplayName("Item Id")]
        public int ItemId { get; set; }
        [Column(TypeName ="Varchar(200)")]
        [DisplayName("Item Name")]
        public string? Item_Name { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        [DisplayName("Quantity")]
        public int Item_Qty { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        [DisplayName("UnitPrice")]
        public float UnitPrice { get; set; }
        [Column(TypeName ="Decimal(18,2)")]
        [DisplayName("Price")]
        public float TotalPrice { get; set; }
        [Column(TypeName ="Varchar(100)")]
        [DisplayName("Item Image")]
        public string Image_Name { get; set; } = string.Empty;
        [Column(TypeName ="Varchar(100)")]
        [DisplayName("User mailId")]
        public string? UserId { get; set; }
        [Column(TypeName ="BIT")]
        public Boolean Delete { get; set; }   
        [NotMapped]
        public List<CountryListModel>? Country { get; set; }
    }
}
