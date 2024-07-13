using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComServices.Models
{
    [NotMapped]
    public class ExceptionDetails
    {
        public string? ExceptionType { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? StackTrace { get;set; }
        public string? HelpLink { get;set;}
        public Exception? InerException { get;set; }
        public string? ExceptionSource { get; set; }
        public string? OffendingMethod { get;set; }
        public string? controllerName { get; set; }
        public string? actionname { get; set; }
        public string? Message { get; set; }
    }
}
