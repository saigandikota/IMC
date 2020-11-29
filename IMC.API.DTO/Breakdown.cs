
using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class Breakdown
    {
        [DataMember]
        public decimal TaxableAmount { get; set; }

        [DataMember]
        public decimal TaxCollectable { get; set; }

        [DataMember]
        public decimal CombinedTaxRate { get; set; }

        [DataMember]
        public decimal StateTaxableAmount { get; set; }

        [DataMember]
        public decimal CountyTaxableAmount { get; set; }

        [DataMember]
        public decimal CountyTaxRate { get; set; }

        [DataMember]
        public decimal CityTaxableAmount { get; set; }

        [DataMember]
        public decimal CityTaxRate { get; set; }

        // International
        [DataMember]
        public decimal CountryTaxableAmount { get; set; }

        [DataMember]
        public decimal CountryTaxRate { get; set; }

        [DataMember]
        public decimal CountryTaxCollectable { get; set; }

        // Canada
        [DataMember]
        public decimal GSTTaxableAmount { get; set; }

        [DataMember]
        public decimal GSTTaxRate { get; set; }

        [DataMember]
        public decimal GST { get; set; }

        [DataMember]
        public decimal PSTTaxableAmount { get; set; }

        [DataMember]
        public decimal PSTTaxRate { get; set; }

        [DataMember]
        public decimal PST { get; set; }

        [DataMember]
        public decimal QSTTaxableAmount { get; set; }

        [DataMember]
        public decimal QSTTaxRate { get; set; }

        [DataMember]
        public decimal QST { get; set; }
    }
}
