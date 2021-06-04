using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray.Payloads
{
    public class ImagePayload
    {
        public static Payload Create(string location)
        {
            return CustomPayload.Create($"<img src=\"{location}\" alt=\"\" />", "Image");
        }
    }
}
