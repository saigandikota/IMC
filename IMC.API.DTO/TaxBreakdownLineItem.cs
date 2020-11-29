using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class TaxBreakdownLineItem:Breakdown
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public decimal StateSalesTaxRate { get; set; }

        [DataMember]
        public decimal StateAmount { get; set; }

        [DataMember]
        public decimal CountyAmount { get; set; }

        [DataMember]
        public decimal CityAmount { get; set; }

        [DataMember]
        public decimal SpecialDistrictTaxableAmount { get; set; }

        [DataMember]
        public decimal SpecialTaxRate { get; set; }

        [DataMember]
        public decimal SpecialDistrictAmount { get; set; }
    }
}
