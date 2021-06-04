using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray
{
    public class LockResponse
    {        
            public string name { get; set; }
            public bool active { get; set; }
            public bool stop_execution { get; set; }
            public string displayed_on_group_uuid { get; set; }
    }
}
