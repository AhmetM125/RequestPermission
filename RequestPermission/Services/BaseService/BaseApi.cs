using Microsoft.Extensions.Http;
using System.Runtime.CompilerServices;
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
    protected async Task HandlePostResponseAsJson<T>(T entity, string requestUrl)
    {
        var response = await HttpClient.PostAsJsonAsync(ApiName + requestUrl, entity);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandleDeleteResponse(Guid id, string requestUrl)
    {
        var response = await HttpClient.DeleteAsync(ApiName + requestUrl);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandleDeleteResponseByIntId(int id, string requestUrl)
    {
        var response = await HttpClient.DeleteAsync(ApiName + requestUrl);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task<List<T>?> HandleReadResponse<T>(string requestUrl)
    {
        var response = await HttpClient.GetAsync(ApiName + requestUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<List<T>>();
            return content ?? Enumerable.Empty<T>().ToList();
        }
        else
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task<T?> HandleSingleReadResponse<T>(string requestUrl)
    {
        var response = await HttpClient.GetAsync(ApiName + requestUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<T>();
            return content ?? default(T);
        }
        else
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    //protected async Task HandleDeleteResponse(Guid id,string requestUrl)
    //{
    //    var response = await HttpClient.DeleteFromJsonAsync(ApiName + requestUrl,);
    //}
}
