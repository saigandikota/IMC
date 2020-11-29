using NUnit.Framework;
using System.IO;
using System.Net;
using System.Text;
namespace TaxService_API_Tests
{
    public class TaxServiceApiTest
    {
        HttpWebRequest req = null;
        string apiUrl = string.Empty;
        string baseUrl = string.Empty;
        string apiKey = string.Empty;
        string zipCode = string.Empty;
        string orderData = string.Empty;

        [SetUp]
        public void Setup()
        {
            baseUrl = "https://localhost:44396/api/tax/";
        }

        [Test]
        public void Get_TaxRates_For_A_Given_Location()
        {
            //Arrange
            zipCode = "33331";
            apiUrl = baseUrl + "taxrates/" + zipCode;
            req = (HttpWebRequest)HttpWebRequest.Create(apiUrl);
            req.ContentType = "application/x-www-form-urlencoded ";
            req.Method = "GET";

            //Act
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //Assert
            Assert.AreEqual(resp.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void TaxForOrder_Returns_TaxInfo_For_A_Given_Order()
        {
            //Arrange
            apiUrl = baseUrl + "taxfororder";
            orderData = "{\"fromCountry\": \"US\",\"fromZip\": \"33323\",\"fromState\": \"FL\",\"toCountry\":\"US\",\"toZip\": \"33331\",\"toState\": \"FL\",  \"amount\": 60,  \"shipping\": 10, \"exemptionType\": \"non_exempt\",  \"lineItems\": [{\"quantity\": 1, \"unitPrice\": 50 }]}";
                
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(apiUrl);
            req.Method = "POST";
            req.ContentType = "application/json";

            byte[] data = Encoding.ASCII.GetBytes(orderData);
            req.ContentLength = data.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            //Act
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //Assert
            Assert.AreEqual(resp.StatusCode, HttpStatusCode.OK);
        }
    }
}