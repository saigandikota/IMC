using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class TaxBreakdown:Breakdown
    {
        [DataMember]
        public decimal StateTaxRate { get; set; }

        [DataMember]
        public decimal StateTaxCollectable { get; set; }

        [DataMember]
        public decimal CountyTaxCollectable { get; set; }

        [DataMember]
        public decimal CityTaxCollectable { get; set; }

        [DataMember]
        public decimal SpecialDistrictTaxableAmount { get; set; }

        [DataMember]
        public decimal SpecialDistrictTaxRate { get; set; }

        [DataMember]
        public decimal SpecialDistrictTaxCollectable { get; set; }

        [DataMember]
        public TaxBreakdownShipping Shipping { get; set; }

        [DataMember]
        public List<TaxBreakdownLineItem> LineItems { get; set; }
    }
}
