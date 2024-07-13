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
    public class UploadFilesAndImagesModel
    {
        [Key]
        public int DocId { get; set; }
        [Required(ErrorMessage = "Please Select Image Or Files")]
        [Column(TypeName = "varchar(200)")]
        public string FileTitle { get; set; } = string.Empty;
        [Column(TypeName = "varchar(500)")]
        public string? ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile? ImageUpload { get; set; }
    }
}
