using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EComServices.Models;
using EComServices.Repository.Implementation;
using Microsoft.Extensions.Caching.Memory;

namespace EComServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly AdbContextConfiguration _context;
        private readonly IMemoryCache _cache;

        public UserRegistrationController(AdbContextConfiguration context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: api/UserRegistration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegistrationModel>>> GetUserRegistration()
        {

            var isavailable = _cache.TryGetValue(CacheKeys.Employees, out List<UserRegistrationModel> employees);
            if (!isavailable)
            {
                employees= await _context.UserRegistration.ToListAsync();
                var CacheEntryPoints = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(5),
                    SlidingExpiration= TimeSpan.FromMinutes(2)
                };
                _cache.Set(CacheKeys.Employees, employees);
                return employees;
            }
            else
            {
                return employees;
            }
            
        }

        // GET: api/UserRegistration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegistrationModel>> GetUserRegistration(int id)
        {
            var userRegistrationModel = await _context.UserRegistration.FindAsync(id);

            if (userRegistrationModel == null)
            {
                return NotFound();
            }

            return userRegistrationModel;
        }

        // PUT: api/UserRegistration/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRegistrationModel(int id, UserRegistrationModel userRegistrationModel)
        {
            if (id != userRegistrationModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userRegistrationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistrationExists(id))
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

        // POST: api/UserRegistration
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult<UserRegistrationModel>> PostUserRegistration(UserRegistrationModel userRegistrationModel)
        {
            ServiceImplementation imp = new ServiceImplementation(_context);
           // UserRegistrationModel regisData = new UserRegistrationModel();
            var regisData = imp.UserRegister(userRegistrationModel);
            _context.UserRegistration.Add(regisData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            } 

            return userRegistrationModel; 
           // return CreatedAtAction("GetUserRegistrationModel", new { id = userRegistrationModel.UserId }, userRegistrationModel);
        }

        // DELETE: api/UserRegistration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRegistration(int id)
        {
            var userRegistrationModel = await _context.UserRegistration.FindAsync(id);
            if (userRegistrationModel == null)
            {
                return NotFound();
            }

            _context.UserRegistration.Remove(userRegistrationModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRegistrationExists(int id)
        {
            return _context.UserRegistration.Any(e => e.UserId == id);
        }
        [HttpGet]
        [Route("Country")]
        public async Task<ActionResult<IEnumerable<CountryListModel>>> GetCountry()
        {
            return await _context.CountryList.ToListAsync();
        }
        [HttpGet]
        [Route("State/{id}")]
        public async Task<ActionResult<IEnumerable<StateListModel>>> GetState(int id)
        {
            return await _context.StateList.Where(m=>m.CountryId==id).ToListAsync();
        }
        public static class CacheKeys
        {
            public static string Employees => "_Employees";
        }
    }
}
