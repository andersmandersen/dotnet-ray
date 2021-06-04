using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class ShowAppPayload
    {
        public static Payload Create()
        {
            return new Payload
            {
                Type = "show_app"                
            };
        }
    }
}
