using EComServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
//using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryWiseProductController : ControllerBase
    {
        private readonly AdbContextConfiguration _context;

        public CategoryWiseProductController(AdbContextConfiguration context)
        {
            _context = context;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSubCategoryWiseListModel>>> GetCategoryWiseProduct()
        {
            return await _context.D_CategoryWiseProductDetail.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryWiseProduct(int? id)
        {
            if (id != 0 && id != null)
            {
                var ProductCategoryWiseItem = _context.D_CategoryWiseProductDetail.ToList().Where(m => m.PSCWId == id);
                return Ok(ProductCategoryWiseItem);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddItemsIntoCart")]
        public async Task<ActionResult<AddedItemsIntoCartForLoggedUser>> PostAddItemsIntoCart([FromBody] AddedItemsIntoCartForLoggedUser CartItem)//[FromQuery] int Item_Quantity, [FromQuery] int Itemid, [FromQuery] string P_Image_Name, [FromQuery] int P_Price, [FromQuery] string ProductName, [FromQuery] string UserId)
        {
            List<AddedItemsIntoCartForLoggedUser> cartitems = new List<AddedItemsIntoCartForLoggedUser>();
            try
            {
                var cartitemm = _context.D_CartItems.ToList().Where(x => x.UserId.Equals(CartItem.UserId) && x.ItemId == CartItem.ItemId);
                if (cartitemm.Count() > 0)
                {
                    cartitems.AddRange(cartitemm);
                    return Ok(cartitems);
                }
                else
                {
                    try
                    {
                        _context.D_CartItems.Add(CartItem);
                        await _context.SaveChangesAsync();
                        return StatusCode(200);

                    }
                    catch (Exception ex)
                    {
                        throw new NotImplementedException(ex.Message);
                    }
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        [HttpGet]
        [Route("GetUserCartItem/{userid}")]
        public async Task<ActionResult<AddedItemsIntoCartForLoggedUser>> GetUserCartItem(string userid)
         {
            try
            {
                var cartitemm = _context.D_CartItems.ToList().Where(x => x.UserId.Equals(userid));
                return Ok(cartitemm);
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        private bool CartItemExists(int id)
        {
            return _context.D_CartItems.Any(e => e.ProductSrNo == id);
        }
        [HttpPut]
        [Route("AddItemsIntoCart/{id}")]
        public async Task<IActionResult> PutAddItemsIntoCart(int id,[FromBody] AddedItemsIntoCartForLoggedUser CartItem)
        {
            if (id != CartItem.ProductSrNo)
            {
                return BadRequest();
            }

            _context.Entry(CartItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(CartItem);
            }           
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(CartItem.ProductSrNo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

    }
}
