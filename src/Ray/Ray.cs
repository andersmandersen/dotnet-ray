using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Threading;
using Velcon.Ray.Payloads;

namespace Velcon.Ray
{
    public class Ray
    {
        private readonly Client _client = new Client();
        private readonly Guid uuid = Guid.NewGuid();
        private StackFrame _stackFrame { get; set; }

        public Ray()
        {

        }

        public Ray(string message)
        {            
            this._stackFrame = new StackFrame(1, true);
            this.Send(message);
        }

        public Ray(Client client)
        {
            this._client = client;            
        }

        /// <summary>
        /// Send basic request to ray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Ray Send<T>(T arg)
        {
            if (this._stackFrame == null)
            {
                this._stackFrame = new StackFrame(1, true);
            }

            var payload = PayloadFactory.GetPayload(arg);
            return this.SendRequest(payload);
        }
        
        public Ray Color(string color)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ColorPayload.Create(color);
            return this.SendRequest(payload);
        }

        public Ray ClearScreen()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ClearScreenPayload.Create();
            return this.SendRequest(payload);
        }

        public Ray NewScreen(string name = "")
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = NewScreenPayload.Create(name);
            return this.SendRequest(payload);
        }

        public Ray ClearAll()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ClearAllPayload.Create();
            return this.SendRequest(payload);
        }

        public Ray Bool(Boolean value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = BoolPayload.Create(value);
            return this.SendRequest(payload);
        }

        public Ray ShowApp()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ShowAppPayload.Create();
            return this.SendRequest(payload);
        }

        public Ray HideApp()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = HideAppPayload.Create();
            return this.SendRequest(payload);
        }

        public Ray String(string value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = StringPayload.Create(value);
            return this.SendRequest(payload);
        }

        public Ray Null()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = NullPayload.Create();
            return this.SendRequest(payload);
        }

        public Ray Hide()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = HidePayload.Create();
            return this.SendRequest(payload);
        }

        public Ray Remove()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = RemovePayload.Create();
            return this.SendRequest(payload);
        }

        public Ray Notify(string value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = NotifyPayload.Create(value);
            return this.SendRequest(payload);
        }

        public Ray Html(string value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = HtmlPayload.Create(value);
            return this.SendRequest(payload);
        }

        public Ray Json<T>(T arg)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = JsonStringPayload.Create(arg);
            return this.SendRequest(payload);
        }

        public Ray Time(DateTime time, string format)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = TimePayload.Create(time, format);
            return this.SendRequest(payload);
        }

        public Ray Custom<T>(T arg, string label)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = CustomPayload.Create(arg, label);
            return this.SendRequest(payload);
        }

        public Ray Image(string location)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ImagePayload.Create(location);
            return this.SendRequest(payload);
        }

        public Ray Size(string size)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = SizePayload.Create(size);
            return this.SendRequest(payload);
        }

        public Ray Green()
        {            
            return this.Color("green");
        }

        public Ray Orange()
        {            
            return this.Color("orange");
        }

        public Ray Red()
        {            
            return this.Color("red");
        }

        public Ray Blue()
        {            
            return this.Color("blue");
        }

        public Ray Purple()
        {            
            return this.Color("purple");
        }

        public Ray Gray()
        {            
            return this.Color("gray");
        }

        public Ray Charles()
        {
            return this.Send("🎶 🎹 🎷 🕺");
        }

        public Ray Pause()
        {
            this._stackFrame = new StackFrame(1, true);

            string lockName = Guid.NewGuid().ToString();

            var payload = CreateLockPayload.Create(lockName);
            this.SendRequest(payload);

            int i = 0;
            while (i < 10)
            {
                Thread.Sleep(1000);

                LockResponse res = this.LockExists(lockName);
                if (!res.active)
                {
                    break;
                }
            }

            return this;
        }

        /// <summary>
        /// Get active host
        /// </summary>
        /// <returns></returns>
        public string GetHost()
        {
            return this._client.Host;
        }

        /// <summary>
        /// Get active port
        /// </summary>
        /// <returns></returns>
        public int GetPort()
        {
            return this._client.Port;
        }

        /// <summary>
        /// Send request to Ray client
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public Ray SendRequest(Payload payload)
        {
            Request r = new Request(this.uuid, payload);

            // Inject origin                                
            foreach (var item in r.payloads)
            {                
                item.Origin = new
                {
                    file = this._stackFrame.GetFileName(),
                    line_number = this._stackFrame.GetFileLineNumber().ToString()
                };
            }

            // Inject Meta
            r.Meta = new
            {
                ray_package_version = "0.1.0"
            };

            var client = new RestClient("http://" + _client.Host + ":" + _client.Port);            
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", r.ToJson(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);            
            
            return this;
        }

        private LockResponse LockExists(string lockName)
        {
            var client = new RestClient("http://" + _client.Host + ":" + _client.Port + "/locks/" + lockName);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response);

            LockResponse resObj = JsonConvert.DeserializeObject<LockResponse>(response.Content);
            if (resObj.stop_execution)
            {
                System.Environment.Exit(1);
            }

            return resObj;
        }
    }
}
