﻿using Newtonsoft.Json;

namespace SinusWebShop
{
    public class Root
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("skip")]
        public int? Skip { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }
}
