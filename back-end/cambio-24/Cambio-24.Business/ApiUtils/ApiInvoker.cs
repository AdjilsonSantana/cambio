using System;
using Newtonsoft.Json;
using RestSharp;

namespace Cambio_24.Business.ApiUtils
{
    class ApiInvoker
    {
        public static T HttpGet<T>(string url)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(url, DataFormat.Json);

                //if (!string.IsNullOrEmpty(token))
                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = client.Get(request);
                var result = JsonConvert.DeserializeObject<T>(response.Content.ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T HttpPost<T>(string url, object input)
        {
            try
            {
                var inputSerialized = JsonConvert.SerializeObject(input, Formatting.Indented);

                var client = new RestClient();
                var request = new RestRequest(url, DataFormat.Json);

                //if (!string.IsNullOrEmpty(token))
                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(inputSerialized);

                var response = client.Post(request);
                var result = JsonConvert.DeserializeObject<T>(response.Content.ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
