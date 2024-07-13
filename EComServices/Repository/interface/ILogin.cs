using EComServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Repository.@interface
{
    public interface ILogin
    {
        public Task<List<UserLogin>> GetLoginId(UserLogin loginCred);
    }
}
