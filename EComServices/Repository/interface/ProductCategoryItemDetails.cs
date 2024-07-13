using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Presentation;
using EComServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EComServices.Repository.Interface
{
    public interface ProductCategoryItemDetails
{
        public Task<List<ProductSubCategoryWiseListModel>> GetItemList(int id);
}
}
