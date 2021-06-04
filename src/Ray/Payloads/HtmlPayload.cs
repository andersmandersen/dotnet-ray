using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class HtmlPayload
    {
        public static Payload Create(string value)
        {
            return CustomPayload.Create(value, "html");
        }
    }
}
