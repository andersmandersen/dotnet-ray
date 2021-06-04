using System;
using System.Collections.Generic;
using System.Text;

namespace Velcon.Ray
{
    public class Client
    {
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 23517;

        public Client()
        {

        }

        public Client(string host, int port)
        {
            this.Host = host;
            this.Port = port;
        }
    }
}
