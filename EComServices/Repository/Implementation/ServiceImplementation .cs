using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
using EComServices.Lib;
using EComServices.Models;
using EComServices.Repository.@interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EComServices.Repository.Implementation
{
    public class ServiceImplementation : IUserRegistration, ICountryList, ILogin
    {
        private readonly AdbContextConfiguration _context;
        //UserRegistrationModel mod = new UserRegistrationModel();
        //private readonly ICountryList _country;
        public ServiceImplementation(AdbContextConfiguration context)//, ICountryList country)
        {
            _context = context;
            //this.mod = mod;
            // _country = country;
        }

        public List<UserLogin> GetLoginId(UserLogin logincred)
        {
            List<UserLogin> list = new List<UserLogin>();
            string mailid = logincred.Email_id;
            string pass = logincred.Password;
            var userpass1 = BCrypt.Net.BCrypt.HashPassword(pass);

            var logincreden = _context.UserRegistration.SingleOrDefault(a => a.Email_Id.Equals(mailid));
            if (logincred != null)
            {
                var userpass = BCrypt.Net.BCrypt.HashPassword(pass);
                if (BCrypt.Net.BCrypt.Verify(logincreden?.Password, userpass))
                {

                    list.Add(logincred);
                    return list;

                }
            }
            else
            {
                throw new NotImplementedException();
            }
            return list;
        }


        public async Task<List<CountryListModel>> CountryList()
        {
                var countrlist = await _context.CountryList.ToListAsync();
                return countrlist;
            

        }
        public async Task<List<StateListModel>> StateList(int countryCode)
        {
           
                var statelist = await _context.StateList.Where(x=> x.CountryId== countryCode).ToListAsync();
                return statelist;
            

        }


        public List<UserRegistrationModel> UserRegistration(UserRegistrationModel userRegistration)
        {
            List<UserRegistrationModel> list = new List<UserRegistrationModel>();
            try
            {
                if (userRegistration != null)
                {
                    var password = userRegistration.Password;
                    var salt = Security.CreateSalt(128);
                    userRegistration.Password = Convert.ToBase64String(Security.Hash(userRegistration.Password, salt));
                    userRegistration.Salt = salt;
                    list.Add(userRegistration);
                    // userRegistration.Password = BCrypt.Net.BCrypt.HashPassword(password);
                    //await _context.AddAsync(userRegistration);
                    //await _context.SaveChangesAsync();
                    return list;

                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }

            return list;


        }
        //UserRegistrationModel userRegistrationModel

        public async Task<int> UpdatePassword(UserLogin newpass)
        {
            int i = 0;
            string mailid = newpass.Email_id;
            string pass = newpass.Password;
            var user = _context.UserRegistration.SingleOrDefault(a => a.Email_Id == newpass.Email_id);

            if (user != null)
            {
                var salt = Security.CreateSalt(128);
                user.Password = Convert.ToBase64String(Security.Hash(user.Password, salt));
                user.Salt = salt;
                //UserRegistrationModel user = _context.UserRegistration.SingleOrDefault(a => a.Email_Id.Equals(mailid));
                //user.Password = BCrypt.Net.BCrypt.HashPassword(pass);
                _context.Update(user);
                i = await _context.SaveChangesAsync();
            }
            //logincreden.Password = update.Password;

            return i;
        }

        //public Task<List<UserLogin>> GetLoginId(UserLogin loginCred)
        //{
        //    throw new NotImplementedException();
        //}
        public UserRegistrationModel UserRegister(UserRegistrationModel regis)
        {
           //string ErroMsg = string.Empty;
            try
            {
                if (regis != null)
                {
                    var password = regis.Password;
                    var salt = Security.CreateSalt(128);
                    regis.Password = Convert.ToBase64String(Security.Hash(regis.Password, salt));
                    regis.Salt = salt;
                    //_context.UserRegistration.Add(regis);
                    // _context.SaveChangesAsync();
                    // return regis;
                    // return ErroMsg="Saved Successfully";
                    //det.Add(regis);
                    return regis;
                }
                //else
                //{
                //    return ErroMsg = "Error in Saving";
                //}
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
            return regis;
        }
    }
}

