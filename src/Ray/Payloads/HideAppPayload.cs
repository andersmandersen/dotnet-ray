using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class HideAppPayload
    {
        public static Payload Create()
        {
            return new Payload
            {
                Type = "hide_app"
            };
        }
    }
}
