using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class ClearScreenPayload
    {
        public static Payload Create()
        {
            return new Payload
            {
                Type = "new_screen",
                Content = ""
            };
        }
    }
}
