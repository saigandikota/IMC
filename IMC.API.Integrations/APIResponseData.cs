using System.Runtime.Serialization;

namespace IMC.API.Integrations
{
    [DataContract]
    public class APIResponseData
    {
        [DataMember]
        public string ResponseContent;

        [DataMember]
        public string ResponseStatus;

        [DataMember]
        public string ResponseStatusCode;
    }
}
