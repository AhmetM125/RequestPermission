namespace RequestPermission.Services.BaseService
{
    public class BaseApi
    {
        protected string ApiName { get; set; }
        protected HttpClient HttpClient { get; init; }
        public BaseApi(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}
