using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class BoolPayload
    {
        public static Payload Create(Boolean value)
        {
            return CustomPayload.Create(value, "Boolean");
        }
    }
}
