using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace recipes_alexander_ccoa.Shared.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<T> Run<T>(string url, HttpMethod httpMethod , object data = null )
        {
            

            HttpRequestMessage msg = new HttpRequestMessage(httpMethod, url);
            if(data != null)msg.Content = JsonContent.Create(msg);

            HttpResponseMessage result = await _httpClient.SendAsync(msg);

           

            int statusCode = (int)result.StatusCode;

            if (statusCode >= 400 && statusCode < 499) throw new Exception("Error en Encontrar el Servidor");
            if (statusCode >= 500)
            {
                throw new Exception("Error en el Servidor");
            }

            if (result.IsSuccessStatusCode)
            {
                T value = await result.Content.ReadFromJsonAsync<T>();


                return (value);
            }

            return default(T);

        }

    }
}
