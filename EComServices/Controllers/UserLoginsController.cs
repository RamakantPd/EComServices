using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EComServices.Models;
using EComServices.Lib;
using EComServices.Repository.RepoClass;

namespace EComServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly AdbContextConfiguration _context;

        public UserLoginsController(AdbContextConfiguration context)
        {
            _context = context;
        }

        // GET: api/UserLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLogin>>> GetLoginUser()
        {
            return await _context.LoginUser.ToListAsync();
        }

        // GET: api/UserLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLogin>> GetUserLogin(int id)
        {
            var userLogin = await _context.LoginUser.FindAsync(id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return userLogin;
        }

        // PUT: api/UserLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogin(int id, UserLogin userLogin)
        {
            if (id != userLogin.Empid)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        // POST: api/UserLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserLogin>> PostUserLogins(UserLogin userLogin)
        {
            
            if (ModelState.IsValid)
            {
               
                string mailid = userLogin.Email_id;
                string pass = userLogin.Password;
                string ErrorMsg = "";

              var  logincreden = _context.UserRegistration.SingleOrDefault(a => a.Email_Id.Equals(mailid));
                if (logincreden != null)
                {
                    userLogin.Empid = logincreden.UserId;
                    
                    var userpass = Convert.ToBase64String(Security.Hash(userLogin.Password, logincreden.Salt));
                    
                    if (userpass == logincreden.Password)
                    {
                        var userId = new LoginSuccessModel()
                        {
                            UserId = userLogin.Email_id
                        };
                        LoginCredentials cl = new LoginCredentials();
                        cl.email = userLogin.Email_id;
                        //cl.password = userLogin.Password;
                        cl.ErrorMsg = ErrorMsg;
                      
                        return Ok(cl);
                    }
                    else
                    {
                        ErrorMsg = "Invalid Password,Try Again?";
                        return Ok(ErrorMsg);
                    }
                }
                ErrorMsg = "Invalid Credentials,Try Again?";
                return Ok(ErrorMsg);
            }
            //return View(userLogin);

            return CreatedAtAction("GetUserLogin", new { id = userLogin.Empid }, userLogin);
        }

        // DELETE: api/UserLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLogin(int id)
        {
            var userLogin = await _context.LoginUser.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            _context.LoginUser.Remove(userLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLoginExists(int id)
        {
            return _context.LoginUser.Any(e => e.Empid == id);
        }
    }
}
