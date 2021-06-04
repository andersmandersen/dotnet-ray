using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class Payload
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public dynamic Content { get; set; }

        [JsonProperty("origin")]
        public dynamic Origin { get; set; }       
    }
}
