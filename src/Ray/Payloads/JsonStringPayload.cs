using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class JsonStringPayload
    {
        public static Payload Create<T>(T arg)
        {
            string jsonString = JsonConvert.SerializeObject(arg);

            return new Payload
            {
                Type = "json_string",
                Content = new { value = jsonString},
            };
        }
    }
}
