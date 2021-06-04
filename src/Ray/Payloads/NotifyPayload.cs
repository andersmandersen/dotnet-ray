using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class NotifyPayload
    {
        public static Payload Create(string value)
        {
            return new Payload
            {
                Type = "notify",
                Content = new { value = value }
            };
        }
    }
}
