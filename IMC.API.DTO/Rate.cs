using System.Runtime.Serialization;

namespace IMC.API.DTO
{
    [DataContract]
    public class Rate
    {
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public decimal CityRate { get; set; }
        [DataMember]
        public decimal CombinedDistrictRate { get; set; }
        [DataMember]
        public decimal CombinedRate { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public decimal CountryRate { get; set; }
        [DataMember]
        public string County { get; set; }
        [DataMember]
        public decimal CountyRate { get; set; }
        [DataMember]
        public decimal DistanceSaleThreshold { get; set; }
        [DataMember]
        public bool FreightTaxable { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal ParkingRate { get; set; }
        [DataMember]
        public decimal ReducedRate { get; set; }
        [DataMember]
        public decimal StandardRate { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public decimal StateRate { get; set; }
        [DataMember]
        public decimal SuperReducedRate { get; set; }
        [DataMember]
        public string Zip { get; set; }
    }
}
