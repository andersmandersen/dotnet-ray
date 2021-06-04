using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class ClearAllPayload
    {
        public static Payload Create()
        {
            return new Payload
            {
                Type = "clear_all",                
            };
        }
    }
}
