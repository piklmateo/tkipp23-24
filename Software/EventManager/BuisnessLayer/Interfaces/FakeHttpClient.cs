using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces
{
    public class FakeHttpClient : IHttpClient
    {
        private readonly HttpClient _client;

        public FakeHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _client.GetAsync(requestUri);
        }
    }
}
