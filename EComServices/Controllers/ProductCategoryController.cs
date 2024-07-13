using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EComServices.Models;

namespace EComServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly AdbContextConfiguration _context;

        public ProductCategoryController(AdbContextConfiguration context)
        {
            _context = context;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategoryModel>>> GetM_ProductCategory()
        {
            return await _context.M_ProductCategory.ToListAsync();
        }

        // GET: api/ProductCategory/5
        [HttpGet("{id}")]
        public IActionResult GetProductCategory(int? id)
        {
            try
            {
                if(id!= null)
                {
                    var productCategoryModel =  _context.M_ProductCategory.ToList().Where(m => m.Prod_CateId == id);
                    return Ok(productCategoryModel);
                }
                else
                {                  
                        return NotFound();
                }
            }catch(Exception e)
            {
                throw;
            }       
        }

        // PUT: api/ProductCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategoryModel(int id, ProductCategoryModel productCategoryModel)
        {
            if (id != productCategoryModel.PId)
            {
                return BadRequest();
            }

            _context.Entry(productCategoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCategoryModel>> PostProductCategoryModel(ProductCategoryModel productCategoryModel)
        {
            _context.M_ProductCategory.Add(productCategoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCategoryModel", new { id = productCategoryModel.PId }, productCategoryModel);
        }

        // DELETE: api/ProductCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategoryModel(int id)
        {
            var productCategoryModel = await _context.M_ProductCategory.FindAsync(id);
            if (productCategoryModel == null)
            {
                return NotFound();
            }

            _context.M_ProductCategory.Remove(productCategoryModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCategoryModelExists(int id)
        {
            return _context.M_ProductCategory.Any(e => e.PId == id);
        }
    }
}
