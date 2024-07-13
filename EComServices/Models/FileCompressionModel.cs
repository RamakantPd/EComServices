using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EComServices.Models
{
    public class FileCompressionModel
    {
        [Key]
        public int id { get; set; }
        public string? FileName { get; set; }
        [NotMapped]
        [DisplayName("Select File To Compress")]
        public IFormFile? FileCompression{get;set;}
    }
}
