namespace Challenge.ToolKit
{
    using Challenge.ToolKit.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    public class WebRequestAdapter : IWebRequestAdapter
    {
        private static HttpClient _httpClient;

        public WebRequestAdapter()
        {
            _httpClient = new HttpClient();
        }

        public byte[] GetRemoteData(string url)
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsByteArrayAsync().Result;
                }
                else
                {
                    throw new Exception("Error en la solicitud. Código de estado: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la solicitud: " + ex.Message);
            }
        }
        public byte[] GetRemoteData(string url, Dictionary<string, string> headers)
        {
            try
            {
                // Crear una solicitud HTTP personalizada con los encabezados proporcionados
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                HttpResponseMessage response = _httpClient.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsByteArrayAsync().Result;
                }
                else
                {
                    throw new Exception("Error en la solicitud. Código de estado: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la solicitud: " + ex.Message);
            }
        }

    }
}
