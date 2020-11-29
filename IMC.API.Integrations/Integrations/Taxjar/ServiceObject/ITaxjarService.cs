namespace IMC.API.Integrations
{
    public interface ITaxjarService
    {
        IMC.API.DTO.Rate GetTaxRateByLocation(APIRequestData request, int zipCode);
        IMC.API.DTO.Tax TaxForOrder(APIRequestData request, IMC.API.DTO.OrderData orderData);
    }
}
