using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Velcon.Ray.Payloads;

namespace Velcon.Ray
{
    public class Request
    {
        public string uuid { get; set; }
        public List<Payload> payloads { get; set; } = new List<Payload>();

        [JsonProperty("meta")]
        public dynamic Meta { get; set; }

        public Request(Guid uuid, Payload payload)
        {
            this.uuid = uuid.ToString();
            this.payloads.Add(payload);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
