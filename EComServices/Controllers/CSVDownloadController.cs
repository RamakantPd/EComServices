//using ClosedXML.Excel;
using ClosedXML.Excel;
using EComServices.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVDownloadController : ControllerBase
    {
        private readonly AdbContextConfiguration _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CSVDownloadController(AdbContextConfiguration context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public ActionResult<IEnumerable<FileContentResult>> DownloadCSV()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "ProductDetailCSV.xlsx";
            List<ProductSubCategoryWiseListModel> obj = new List<ProductSubCategoryWiseListModel>();
            try
            {
                //AddedItemsIntoCartForLoggedUser dt = new AddedItemsIntoCartForLoggedUser
                //{
                //    registr = await _country.RegistrationData()
                //};
              var PDetail = _context.D_CategoryWiseProductDetail.ToList();
                //List<AddedItemsIntoCartForLoggedUser> dt = new List<AddedItemsIntoCartForLoggedUser>();
                //dt.Add(PDetail);
                if (PDetail != null)
                {
                    obj.AddRange(PDetail);
                    using (var workbook = new XLWorkbook())
                    {
                        IXLWorksheet worksheet =
                        workbook.Worksheets.Add("Authors");
                        worksheet.Cell(1, 1).Value = "Id";
                        worksheet.Cell(1, 2).Value = "Product Category";
                        worksheet.Cell(1, 3).Value = "Product Name";
                        worksheet.Cell(1, 4).Value = "Price";
                        worksheet.Cell(1, 5).Value = "Description";
                        for (int index = 1; index <= PDetail.Count; index++)
                        {
                            worksheet.Cell(index + 1, 1).Value = PDetail[index - 1].PSCWId;
                            worksheet.Cell(index + 1, 2).Value = PDetail[index - 1].ProductWiseCategory;
                            worksheet.Cell(index + 1, 3).Value = PDetail[index - 1].ProductName;
                            worksheet.Cell(index + 1, 4).Value = PDetail[index - 1].P_Price;
                            worksheet.Cell(index + 1, 5).Value = PDetail[index - 1].P_Description;
                        }
                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            stream.Position = 0;
                            return File(content, contentType, fileName);
                        }
                    }
                }
                else
                {
                    //ViewBag.ErrorMsg = "No Record Found";
                   using (var stream = new MemoryStream())
                        {
                            //workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            stream.Position = 0;
                            return File(content, contentType, fileName);
                        }
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
