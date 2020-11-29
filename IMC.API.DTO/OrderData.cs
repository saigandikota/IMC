using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class OrderData
    {
       [DataMember]
        public string FromCountry { get; set; }
        [DataMember]
        public string FromZip { get; set; }
        [DataMember]
        public string FromState { get; set; }
        [DataMember]
        public string ToCountry { get; set; }
        [DataMember]
        public string ToZip { get; set; }
        [DataMember]
        public string ToState { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public double Shipping { get; set; }
        [DataMember]
        public string ExemptionType { get; set; }
        [DataMember]
        public List<LineItem> LineItems { get; set; }

    }
    [DataContract]
    public class LineItem
    {
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public double UnitPrice { get; set; }
    }
}
