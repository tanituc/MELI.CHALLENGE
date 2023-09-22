namespace Challenge.ToolKit
{
    using Challenge.ToolKit.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class WebRequestAdapter : IWebRequestAdapter
    {
        private HttpClient _httpClient;

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

    }
}
