using System.Text;
using System.Text.Json;

namespace RequestPermission.Services.BaseService;

public class BaseApi
{
    protected string ApiName { get; set; }
    protected HttpClient HttpClient { get; init; }
    public BaseApi(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
    protected async Task HandlePutResponse<T>(T entity)
    {
        var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
        var response = await HttpClient.PutAsync(ApiName, content);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandlePutResponseJson<T>(T entity)
    {
        var response = await HttpClient.PutAsJsonAsync(ApiName, entity);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandlePostResponse<T>(T entity)
    {
        var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
        var response = await HttpClient.PostAsync(ApiName, content);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandlePostResponseAsJson<T>(T entity,string requestUrl)
    {
        var response = await HttpClient.PostAsJsonAsync(ApiName + requestUrl, entity);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
}
