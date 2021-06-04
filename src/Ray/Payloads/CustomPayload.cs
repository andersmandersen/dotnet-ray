using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class CustomPayload
    {
        public static Payload Create<T>(T arg, string label)
        {
            return new Payload
            {
                Type = "custom",
                Content = new { content = arg, label = label },
            };
        }

        public static Payload Create(string label)
        {
            return new Payload
            {
                Type = "custom",
                Content = new { content = "", label = label },
            };
        }
    }
}
