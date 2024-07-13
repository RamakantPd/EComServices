using EComServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Repository.@interface
{
    public interface ICountryList
    {
        public Task<List<CountryListModel>> CountryList();
        public Task<List<StateListModel>> StateList(int countryCode);
    }
}
