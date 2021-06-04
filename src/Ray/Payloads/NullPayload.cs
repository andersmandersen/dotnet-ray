using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class NullPayload
    {
        public static Payload Create()
        {
            return CustomPayload.Create("Null");
        }
    }
}
