namespace Velcon.Ray.Payloads
{
    public class ColorPayload
    {
        public static Payload Create(string color)
        {
            return new Payload
            {
                Type = "color",
                Content = new { color = color }
            };
        }
    }
}
