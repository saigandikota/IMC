using Newtonsoft.Json;
using IMC.API.DTO;
using AutoMapper;
using IMC.API.Integrations.Taxjar.MessageBodies;

namespace IMC.API.Integrations
{
    public class TaxjarService : ITaxjarService
    {
        public IMC.API.DTO.Rate GetTaxRateByLocation(APIRequestData apiRequest, int zipCode)
        {
            APIResponseData apiResponse = new APIResponseData();
            string urlData = string.Empty;

            apiRequest.VendorName = "Taxjar";
            apiRequest.HttpRequestType = HttpRequestTypeEnum.GET;
            apiRequest.PostURL = apiRequest.BaseURL + "rates/" + zipCode;

            //Execuring HTTP GET Action to make API call to Vendor API
            ApiHelper.ExecuteHttpAction(apiRequest, out apiResponse);

            RateResponse rateResp = JsonConvert.DeserializeObject<RateResponse>(apiResponse.ResponseContent);

            var toDTOMapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<RateResponseAttributes, IMC.API.DTO.Rate>());
            var toDTOMapper = toDTOMapperConfig.CreateMapper();
            IMC.API.DTO.Rate rate = toDTOMapper.Map<IMC.API.DTO.Rate>(rateResp.Rate);

            toDTOMapperConfig = null;
            toDTOMapper = null;

            return rate;
        }

        public IMC.API.DTO.Tax TaxForOrder(APIRequestData apiRequest, OrderData orderData)
        {
            APIResponseData apiResponse = new APIResponseData();
            TaxResponse response = null;
            string jsonString = string.Empty;

            var toVendorEntityMapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderData, TaxForOrderRequest>();
                cfg.CreateMap<IMC.API.DTO.LineItem, IMC.API.Integrations.Taxjar.MessageBodies.LineItem>();
            });
            var toVendorEntityMapper = toVendorEntityMapperConfig.CreateMapper();
            TaxForOrderRequest taxForOrder = toVendorEntityMapper.Map<TaxForOrderRequest>(orderData);

            jsonString = JsonConvert.SerializeObject(taxForOrder);

            apiRequest.VendorName = "Taxjar";
            apiRequest.PostURL = apiRequest.BaseURL + "taxes/";
            apiRequest.HttpRequestType = HttpRequestTypeEnum.POST;
            apiRequest.PostDataJSON = jsonString;

            //Execuring HTTP POST Action to make API call to Vendor API
            ApiHelper.ExecuteHttpAction(apiRequest, out apiResponse);

            string result = apiResponse.ResponseContent;

            response = JsonConvert.DeserializeObject<TaxResponse>(apiResponse.ResponseContent);


            var toDTOMapperConfig = new MapperConfiguration(cfg1 => {
                cfg1.CreateMap<TaxResponseAttributes, IMC.API.DTO.Tax>();
                cfg1.CreateMap<IMC.API.Integrations.Taxjar.MessageBodies.TaxJurisdictions, IMC.API.DTO.TaxJurisdictions>();
                cfg1.CreateMap<IMC.API.Integrations.Taxjar.MessageBodies.TaxBreakdown, IMC.API.DTO.TaxBreakdown>();
                cfg1.CreateMap<IMC.API.Integrations.Taxjar.MessageBodies.TaxBreakdownLineItem, IMC.API.DTO.TaxBreakdownLineItem>();
                cfg1.CreateMap<IMC.API.Integrations.Taxjar.MessageBodies.TaxBreakdownShipping, IMC.API.DTO.TaxBreakdownShipping>();
                cfg1.CreateMap<IMC.API.Integrations.Taxjar.MessageBodies.Breakdown, IMC.API.DTO.Breakdown>();
            });
            var toDTOMapper = toDTOMapperConfig.CreateMapper();
            IMC.API.DTO.Tax tax = toDTOMapper.Map<IMC.API.DTO.Tax>(response.Tax);

            //Clear all the object assignments
            toVendorEntityMapperConfig = null;
            toDTOMapperConfig = null;
            toVendorEntityMapper = null;
            toDTOMapper = null;

            return tax;
        }
    }
}
