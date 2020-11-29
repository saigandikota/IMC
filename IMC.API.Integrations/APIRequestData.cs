using System.Runtime.Serialization;
namespace IMC.API.Integrations
{
    [DataContract]
    public class APIRequestData
    {
        [DataMember]
        public string VendorName;
        [DataMember]
        public string APIKey;
        [DataMember]
        public string Token;
        [DataMember]
        public string BaseURL;
        [DataMember]
        public HttpRequestTypeEnum HttpRequestType;
        [DataMember]
        public string ContentType;
        [DataMember]
        public string UserAgent;
        [DataMember]
        public string PostURL;
        [DataMember]
        public string PostDataJSON;
    }
}
