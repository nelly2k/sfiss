using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Sfiss.Common.Contract;

namespace Sfiss.Common.Communication
{
    public interface ICommunication:IService
    {
        HttpClient GetClientFor(Service service);
    }

    public class Communication : ICommunication
    {
        public HttpClient GetClientFor(Service service)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"http://localhost:{(int)service}/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }

    public enum Service
    {
        Exercise = 8406,
        Workout = 8175
    }
}
