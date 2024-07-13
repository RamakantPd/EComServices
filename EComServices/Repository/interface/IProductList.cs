using EComServices.Models;

namespace EComServices.Repository
{
    public interface IProductList
    {
        public Task<List<ProductModel>> GetProduct();
    }
}
