using NUnit.Framework;
using System.IO;
using System.Net;
using System.Text;

namespace TaxjarAPI_UnitTest
{
    public class TaxjarApiTest
    {
        HttpWebRequest req=null;
        string apiUrl=string.Empty;
        string baseUrl = string.Empty;
        string apiKey = string.Empty;
        string zipCode = string.Empty;
        string orderData = string.Empty;

        [SetUp]
        public void Setup()
        {
            baseUrl = "https://api.taxjar.com/v2/";
            apiKey = "d302d1cace4d135862ad779f59cd2ea6";
        }

        [Test]
        public void Get_TaxRates_For_A_Given_Location()
        {
            //Arrange
            zipCode = "33331";
            apiUrl = baseUrl + "rates/" + zipCode;
            req = (HttpWebRequest)HttpWebRequest.Create(apiUrl);
            req.ContentType = "application/x-www-form-urlencoded ";
            req.Method = "GET";
            req.Headers.Add(string.Format("Authorization: Bearer {0}", apiKey));

            //Act
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //Assert
            Assert.AreEqual(resp.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void TaxForOrder_Returns_TaxInfo_For_A_Given_Order()
        {
            //Arrange
            apiUrl = baseUrl + "taxes/";
            orderData = "{\"from_country\":\"US\",\"from_zip\":\"33323\",\"from_state\":\"FL\",\"to_country\":\"US\",\"to_zip\":\"33331\",\"to_state\":\"FL\",\"amount\":60.0,\"shipping\":10.0,\"exemption_type\":\"non_exempt\",\"line_items\":[{\"quantity\":1,\"unit_price\":50.0}]}";
            apiUrl = baseUrl + "taxes/";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(apiUrl);
            req.Method = "POST";
            req.Headers.Add(string.Format("Authorization: Bearer {0}", apiKey));
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