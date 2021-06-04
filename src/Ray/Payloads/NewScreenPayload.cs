namespace Velcon.Ray.Payloads
{
    public class NewScreenPayload
    {
        public static Payload Create(string name)
        {
            return new Payload
            {
                Type = "new_screen",
                Content = new { name = name }
            };
        }
    }
}
