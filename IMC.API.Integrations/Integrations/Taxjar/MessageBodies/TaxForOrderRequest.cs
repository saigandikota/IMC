﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace IMC.API.Integrations.Taxjar.MessageBodies
{
    public class TaxForOrderRequest
    {
        [JsonProperty("from_country")]
        public string FromCountry { get; set; }
        [JsonProperty("from_zip")]
        public string FromZip { get; set; }
        [JsonProperty("from_state")]
        public string FromState { get; set; }
        [JsonProperty("to_country")]
        public string ToCountry { get; set; }
        [JsonProperty("to_zip")]
        public string ToZip { get; set; }
        [JsonProperty("to_state")]
        public string ToState { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("shipping")]
        public double Shipping { get; set; }
        [JsonProperty("exemption_type")]
        public string ExemptionType { get; set; }
        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }
    }
    
    public class LineItem
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }
    }
}
