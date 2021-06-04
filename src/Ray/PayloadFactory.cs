using Velcon.Ray.Payloads;

namespace Velcon.Ray
{
    public class PayloadFactory
    {
        public static Payload GetPayload<T>(T arg)
        {
            return LogPayload.Create<T>(arg);
        }
    }
}
