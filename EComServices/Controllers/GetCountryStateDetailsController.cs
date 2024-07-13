using EComServices.Repository.@interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EComServices.Controllers
{
    [Route("api/GetCountryStateDetails")]
    [ApiController]
    public class GetCountryStateDetailsController : ControllerBase
    {
        private readonly ICountryList _country;
        private readonly IStateList _stateList;
        public GetCountryStateDetailsController(ICountryList country, IStateList stateList)
        {
            _country = country;
            _stateList = stateList;
        }

        [HttpGet]
        [Route("GetCountryDetails")]
        public async Task<IActionResult> GetCountry()
        {
            
            var countryDetails = await _country.CountryList();
            return Ok(countryDetails);
        }

        [HttpGet]
        [Route("GetStateDetails")]
        public async Task<IActionResult> GetStateDetails(int countryCode)
        {
            var stateDetails = await _country.StateList(countryCode);
            return Ok(stateDetails);
        }

    }
}
