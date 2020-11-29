using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class TaxBreakdownShipping : Breakdown
    {
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
        public decimal SpecialDistrictTaxRate { get; set; }

        [DataMember]
        public decimal SpecialDistrictAmount { get; set; }
    }
}
