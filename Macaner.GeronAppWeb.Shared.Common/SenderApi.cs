
using Macaner.GeronAppWeb.Shared.Interface;
using System.Threading.Tasks;
using System.Web;

namespace Macaner.GeronAppWeb.Shared.Common
{
    public  class SenderApi : ISenderApi
    {

        #region Metodos Sincronos
        public HttpResponseMessage GetApi(string Url, Dictionary<string, string> queryParam)
        {
            HttpClient httpClient = CallHttp();
            UriBuilder builder = new UriBuilder(Url);
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (var item in queryParam)
            {
                query.Add(item.Key, item.Value);
            }
            builder.Query = query.ToString();
            var result = httpClient.GetAsync(builder.Uri).Result;
            httpClient.Dispose();
            return result;
        }

        public HttpResponseMessage GetApiWithoutParam(string Url)
        {
            HttpClient httpClient = CallHttp();
            UriBuilder builder = new UriBuilder(Url);
            var result = httpClient.GetAsync(builder.Uri).Result;
            httpClient.Dispose();
            return result;
        }
        public HttpResponseMessage PostApi(string Url, HttpContent content)
        {
            try
            {
                HttpClient httpClient = CallHttp();
                UriBuilder builder = new UriBuilder(Url);
                var result = httpClient.PostAsync(builder.Uri, content).Result;
                httpClient.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                throw;
            }
           
        }

        public HttpResponseMessage PutApi(string Url, HttpContent content)
        {
            HttpClient httpClient = CallHttp();
            UriBuilder builder = new UriBuilder(Url);
            var result = httpClient.PutAsync(builder.Uri, content).Result;
            httpClient.Dispose();
            return result;
        }

        public HttpClient CallHttp()
        {
            HttpClientHandler handler = new HttpClientHandler();
           // handler.UseDefaultCredentials = true;
            HttpClient httpClient = new HttpClient(handler);
            return httpClient;
        }
        #endregion

        #region Metodos Asincronos
        public async Task<HttpResponseMessage> GetApiAsync(string Url, Dictionary<string, string> queryParam)
        {
            HttpClient httpClient = await CallHttpAsync();
            UriBuilder builder = new UriBuilder(Url);
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (var item in queryParam)
            {
                query.Add(item.Key, item.Value);
            }
            builder.Query = query.ToString();
            var result = httpClient.GetAsync(builder.Uri).Result;
            httpClient.Dispose();
            return result;
        }

        public async Task<HttpResponseMessage> GetApiWithoutParamAsync(string Url)
        {
            HttpClient httpClient = await CallHttpAsync();
            UriBuilder builder = new UriBuilder(Url);
            var result = httpClient.GetAsync(builder.Uri).Result;
            httpClient.Dispose();
            return result;
        }
        public async Task<HttpResponseMessage> PostApiAsync(string Url, HttpContent content)
        {
            try
            {
                using var httpClient = new HttpClient { BaseAddress = new Uri(Url) };
                var response = await httpClient.PostAsync(Url, content);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
           
        }

        public async Task<HttpResponseMessage> PutApiAsync(string Url, HttpContent content)
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri(Url) };

            var response = await httpClient.PutAsync(Url, null);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpClient> CallHttpAsync()
        {
            HttpClient httpClient = new HttpClient();
            return await Task.FromResult(httpClient);
        }
        #endregion
       
    }
}
