using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class TaxJurisdictions
    {
        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string City { get; set; }
    }
}
