using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class Tax
    {
        [DataMember]
        public decimal OrderTotalAmount { get; set; }

        [DataMember]
        public decimal Shipping { get; set; }

        [DataMember]
        public decimal TaxableAmount { get; set; }

        [DataMember]
        public decimal AmountToCollect { get; set; }

        [DataMember]
        public decimal Rate { get; set; }

        [DataMember]
        public bool HasNexus { get; set; }

        [DataMember]
        public bool FreightTaxable { get; set; }

        [DataMember]
        public string TaxSource { get; set; }

        [DataMember]
        public string ExemptionType { get; set; }

        [DataMember]
        public TaxJurisdictions Jurisdictions { get; set; }

        [DataMember]
        public TaxBreakdown Breakdown { get; set; }
    }
}
