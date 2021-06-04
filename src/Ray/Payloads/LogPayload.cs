using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class LogPayload
    {
        public static Payload Create<T>(T arg)
        {
            if (arg is object)
            {
                return new Payload
                {
                    Type = "log",
                    Content = new { values = new dynamic[] { JsonConvert.SerializeObject(arg) } },
                };                
            }

            return new Payload
            {
                Type = "log",
                Content = new { values = new dynamic[] { arg } },                
            };
        }
    }
}
