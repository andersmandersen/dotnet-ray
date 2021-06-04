using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class CreateLockPayload
    {
        public static Payload Create(string name)
        {
            return new Payload
            {
                Type = "create_lock",
                Content = new { name = name }
            };
        }
    }
}
