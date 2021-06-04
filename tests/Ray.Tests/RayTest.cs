using Xunit;
using Velcon.Ray;

namespace Velcon.Ray.Tests
{
    public class RayTest
    {

        [Fact]
        public void TestCanSetClientHost()
        {
            Client client = new Client("192.168.0.1", 200);

            Assert.Equal(new Ray(client).GetHost(), client.Host);
        }

        [Fact]
        public void TestCanSetClientPort()
        {
            Client client = new Client("192.168.0.1", 200);

            Assert.Equal(new Ray(client).GetPort(), client.Port);
        }
    }
}
