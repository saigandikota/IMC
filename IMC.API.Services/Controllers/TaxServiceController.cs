using IMC.API.Integrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IMC.API.Services.Controllers
{
    [Route("api/tax")]
    [ApiController]
    public class TaxServiceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITaxjarService _taxjarService;

        public TaxServiceController(IConfiguration configuration,
                                    ITaxjarService taxjarService)
        {
            _configuration = configuration;
            _taxjarService = taxjarService;
        }


        // GET api/tax/taxrates/5
        [HttpGet("taxrates/{zipcode}")]
        public IMC.API.DTO.Rate GetTaxRateByLocation(int zipcode)
        {
            IMC.API.DTO.Rate rate = null;
            APIRequestData request = new APIRequestData();
            request.APIKey = _configuration.GetSection("Taxjar").GetSection("APIKey").Value;
            request.BaseURL = _configuration.GetSection("Taxjar").GetSection("BaseUrl").Value;

            rate = _taxjarService.GetTaxRateByLocation(request, zipcode);

            return rate;
        }

        // POST api/tax/taxfororder
        [HttpPost("taxfororder")]
        public IMC.API.DTO.Tax CaclculateTaxForOrder(IMC.API.DTO.OrderData orderData)
        {
            IMC.API.DTO.Tax tax = null;
            APIRequestData request = new APIRequestData();
            request.APIKey = _configuration.GetSection("Taxjar").GetSection("APIKey").Value;
            request.BaseURL = _configuration.GetSection("Taxjar").GetSection("BaseUrl").Value;

            tax = _taxjarService.TaxForOrder(request, orderData);

            return tax;
        }
    }
}
