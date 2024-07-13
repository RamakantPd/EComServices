using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Lib
{
    public class UploadFilesAndDownload
    {
        private string FilePath(string filenm)
        {
            string filePath = "";
            string msg = "";
            //var exten = filename.Split(".");
            // var extns = exten[1];
            // string filePath = FilePath(filenm);
            var exten = Path.GetExtension(filenm);
            if (exten == "jpg" || exten == ".jpeg" || exten == "gif" || exten == "png")
            {
                filePath = "/image" + filenm;
            }
            else
            {
                filePath = "/document" + filenm;
            }
            if (filePath == null)
            {
                //return Content("File not found");
                return msg = "File not found";
            }
            return filePath;
        }
        //private string FilePath()
        //{

        //}
        public async Task<Object> DownloadFilesAndImage(string filename)
        {
            string filePath = "";
            //var exten = filename.Split(".");
            // var extns = exten[1];
            filePath = FilePath(filename);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);
            FilePath(path);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return memory;
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var extn = Path.GetExtension(path).ToLowerInvariant();
            return types[extn];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt","text/plan" },
                {".pdf","application/pdf" },
                {".doc","application/vnd.ms-word" },
                {".docx","application/vnd.ms-word" },
                {".xls","application/vnd.ms-excel" },
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png","image/png" },
                {".jpg","image/jpg" },
                {".jpeg","image/jpeg" },
                {".gif","image/gif" },
                {".csv","text/csv" }
            };
        }
    }
}
