using EComServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Repository.@interface
{
    public interface IUserRegistration
    {
        public List<UserRegistrationModel> UserRegistration(UserRegistrationModel userRegistrationModel);
    }
}
