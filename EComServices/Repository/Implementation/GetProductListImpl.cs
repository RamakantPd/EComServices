using EComServices.Models;
using Microsoft.EntityFrameworkCore;

namespace EComServices.Repository.Implementation
{
    public class GetProductListImpl : IProductList
    {
        private readonly AdbContextConfiguration _context;
        public GetProductListImpl(AdbContextConfiguration context)
        {
            _context = context;
        }
        public async Task<List<ProductModel>> GetProduct()
        {
            return await _context.M_ProductType.ToListAsync();
        }
    }
}
