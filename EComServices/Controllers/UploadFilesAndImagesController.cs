using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EComServices.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using ClosedXML.Excel;
namespace EComServices.Controllers
{
   // [ExceptionFilter]
    public class UploadFilesAndImagesController : Controller
    {
        private readonly AdbContextConfiguration _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadFilesAndImagesController(AdbContextConfiguration context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: UploadFilesAndImages
        public async Task<IActionResult> Index()
        {
            var docList = await _context.Documents.ToListAsync();
            return View(docList);
        }

        // GET: UploadFilesAndImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadFilesAndImagesModel = await _context.Documents
                .FirstOrDefaultAsync(m => m.DocId == id);
            if (uploadFilesAndImagesModel == null)
            {
                return NotFound();
            }

            return View(uploadFilesAndImagesModel);
        }

        // GET: UploadFilesAndImages/Create
        public IActionResult Create()
        {
            //var sessionIdd = JsonConvert.DeserializeObject<LoginSuccessModel>(HttpContext.Session.GetString("UserId"));
            //LoginSuccessModel loginsec = new LoginSuccessModel();
            //loginsec.UserId = sessionIdd;
            var sessionidd = HttpContext.Session.GetString("UserId");
            return View();
        }

        // POST: UploadFilesAndImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit =104857600)]
        public async Task<IActionResult> Create([Bind("DocId,FileTitle,ImageUpload")] UploadFilesAndImagesModel uploadFilesAndImagesModel)
        {
            string path = "";
            if (ModelState.IsValid)
            {
                //FileInfo fn = new FileInfo(uploadFilesAndImagesModel.ImageUpload.FileName);
                //var filenm = @"C:\Users\HP\Downloads\" + fn.Name;
                //using (var stream = System.IO.File.Open(filenm, FileMode.Open, FileAccess.Read))
                //{
                //    using (var readr = new StreamReader(stream))
                //    {
                //        var dt = readr.ReadToEnd();
                //    }
                //    using (var reader = ExcelReaderFactory.CreateReader(stream))
                //    {
                //        if (reader.Read())
                //        {
                //            var nm = reader.GetValue(0).ToString();
                //        }
                //    }
                //}
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string FileName = Path.GetFileNameWithoutExtension(uploadFilesAndImagesModel.ImageUpload.FileName);
                string exten = Path.GetExtension(uploadFilesAndImagesModel.ImageUpload.FileName);
                if (exten == ".jpg" || exten == ".jpeg" || exten == ".png" || exten == ".gif")
                {
                    uploadFilesAndImagesModel.ImageName = FileName += exten;
                    path = Path.Combine(wwwrootpath + "/image/", FileName);
                }
                else
                if(exten == ".mp4")
                {
                    uploadFilesAndImagesModel.ImageName = FileName += exten; 
                     path = Path.Combine(wwwrootpath + "/Videos/", FileName);
                }
                else
                {
                    //using(var xlwork=new IXLWorksheets())
                    // {

                    //     foreach()
                    // }
                   
                    uploadFilesAndImagesModel.ImageName = FileName += exten;
                    path = Path.Combine(wwwrootpath + "/document/", FileName);
                }
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadFilesAndImagesModel.ImageUpload.CopyToAsync(fileStream);
                }
                _context.Add(uploadFilesAndImagesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uploadFilesAndImagesModel);
        }

        // GET: UploadFilesAndImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadFilesAndImagesModel = await _context.Documents.FindAsync(id);
            if (uploadFilesAndImagesModel == null)
            {
                return NotFound();
            }
            return View(uploadFilesAndImagesModel);
        }

        // POST: UploadFilesAndImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocId,FileTitle,ImageName")] UploadFilesAndImagesModel uploadFilesAndImagesModel)
        {
            if (id != uploadFilesAndImagesModel.DocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uploadFilesAndImagesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UploadFilesAndImagesModelExists(uploadFilesAndImagesModel.DocId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(uploadFilesAndImagesModel);
        }

        // GET: UploadFilesAndImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadFilesAndImagesModel = await _context.Documents
                .FirstOrDefaultAsync(m => m.DocId == id);
            if (uploadFilesAndImagesModel == null)
            {
                return NotFound();
            }

            return View(uploadFilesAndImagesModel);
        }

        // POST: UploadFilesAndImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uploadFilesAndImagesModel = await _context.Documents.FindAsync(id);
            _context.Documents.Remove(uploadFilesAndImagesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UploadFilesAndImagesModelExists(int id)
        {
            return _context.Documents.Any(e => e.DocId == id);
        }
        public async Task<IActionResult> DownloadFiles(string filename)
        {
            //UploadFilesAndDownload dwn = new UploadFilesAndDownload();
            //var memory = dwn.DownloadFilesAndImage(filename);
            //string contentype = dwn.GetContentType(filename);
            string filePath = "";
            //var exten = filename.Split(".");
            // var extns = exten[1];
            var exten = Path.GetExtension(filename);
            if (exten == "jpg" || exten == ".jpeg" || exten == "gif" || exten == "png")
            {
                filePath = "./image/" + filename;
            }
            else
            {
                filePath = "./document/" + filename;
            }
            if (filePath == null)
            {
                return Content("File not found");
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
           // Response.Headers.Add("Content-Disposition") = "inline";
            Response.Headers["Content-Disposition"] = "inline";
            return File(memory, GetContentType(path), Path.GetFileName(path));
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
