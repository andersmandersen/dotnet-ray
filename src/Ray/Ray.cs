using DotNet.WebUtils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            this.SendRequest(payload);

            return this;
        }
        
        public Ray Color(string color)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ColorPayload.Create(color);
            this.SendRequest(payload);
            return this;
        }

        public Ray ClearScreen()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ClearScreenPayload.Create();
            this.SendRequest(payload);

            return this;
        }

        public Ray NewScreen(string name = "")
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = NewScreenPayload.Create(name);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray ClearAll()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ClearAllPayload.Create();
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Bool(Boolean value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = BoolPayload.Create(value);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray ShowApp()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ShowAppPayload.Create();
            this.SendRequest(payload);
            
            return this;
        }

        public Ray HideApp()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = HideAppPayload.Create();
            this.SendRequest(payload);
            
            return this;
        }

        public Ray String(string value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = StringPayload.Create(value);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Null()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = NullPayload.Create();
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Hide()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = HidePayload.Create();
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Remove()
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = RemovePayload.Create();
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Notify(string value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = NotifyPayload.Create(value);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Html(string value)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = HtmlPayload.Create(value);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Json<T>(T arg)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = JsonStringPayload.Create(arg);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Time(DateTime time, string format)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = TimePayload.Create(time, format);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Custom<T>(T arg, string label)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = CustomPayload.Create(arg, label);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Image(string location)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = ImagePayload.Create(location);
            this.SendRequest(payload);
            
            return this;
        }

        public Ray Size(string size)
        {
            this._stackFrame = new StackFrame(1, true);

            var payload = SizePayload.Create(size);
            this.SendRequest(payload);
            
            return this;
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

        public async Task<Ray> PauseAsync()
        {
            this._stackFrame = new StackFrame(1, true);

            string lockName = Guid.NewGuid().ToString();

            var payload = CreateLockPayload.Create(lockName);
            await this.SendRequest(payload);

            int i = 0;
            while (i < 10)
            {
                Thread.Sleep(1000);

                LockResponse res = await this.LockExistsAsync(lockName);
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
        private async Task<Ray> SendRequest(Payload payload)
        {
            Request r = new Request(this.uuid, payload);

            // Inject origin                                
            foreach (var item in r.payloads)
            {                
                item.Origin = new
                {
                    file = this._stackFrame.GetFileName() == null ? "Unkown file" : this._stackFrame.GetFileName(),
                    line_number = this._stackFrame.GetFileLineNumber().ToString()
                };
            }

            // Inject Meta
            r.Meta = new
            {
                ray_package_version = "0.1.1"
            };



            var client = new HttpClient();
            await client.PostAsync("http://" + _client.Host + ":" + _client.Port, new StringContent(r.ToJson(), Encoding.UTF8, "application/json"));

            return this;
        }

        private async Task<LockResponse> LockExistsAsync(string lockName)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://" + _client.Host + ":" + _client.Port + "/locks/" + lockName);

            string body = await response.Content.ReadAsStringAsync();
            LockResponse resObj = JsonConvert.DeserializeObject<LockResponse>(body);
            if (resObj.stop_execution)
            {
                System.Environment.Exit(1);
            }

            return resObj;
            
        }
    }
}
