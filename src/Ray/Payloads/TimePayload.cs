using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class TimePayload
    {
        public static Payload Create(DateTime time, string format)
        {
            TimeZoneInfo curTimeZone = TimeZoneInfo.Local;

            return new Payload
            {
                Type = "carbon",
                Content = new {
                    formatted = time.ToString(format),
                    timestamp = time.ToUniversalTime(),
                    timezone = curTimeZone.DisplayName,
                },
            };
        }
    }
}
