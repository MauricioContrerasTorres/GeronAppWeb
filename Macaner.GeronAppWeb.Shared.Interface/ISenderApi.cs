namespace Macaner.GeronAppWeb.Shared.Interface
{
    public interface ISenderApi
    {
        #region Metodos Sincronos
        HttpResponseMessage GetApi(string Url, Dictionary<string, string> queryParam);
        HttpResponseMessage GetApiWithoutParam(string Url);
        HttpResponseMessage PostApi(string Url, HttpContent content);
        HttpResponseMessage PutApi(string Url, HttpContent content);
        HttpClient CallHttp();
        #endregion

        #region Metodos Asincronos
        Task<HttpResponseMessage> GetApiAsync(string Url, Dictionary<string, string> queryParam);
        Task<HttpResponseMessage> GetApiWithoutParamAsync(string Url);
        Task<HttpResponseMessage> PostApiAsync(string Url, HttpContent content);
        Task<HttpResponseMessage> PutApiAsync(string Url, HttpContent content);
        Task<HttpClient> CallHttpAsync();
        #endregion
    }
}
