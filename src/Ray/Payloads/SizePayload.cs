using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class SizePayload
    {
        public static Payload Create(string size)
        {
            return new Payload
            {
                Type = "size",
                Content = new { size = size }
            };
        }
    }
}
