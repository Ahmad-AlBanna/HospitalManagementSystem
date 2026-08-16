using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace HospitalManagementSystemWeb.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _context;


    public ApiService(
        HttpClient httpClient,
        IHttpContextAccessor context)
    {
        _httpClient = httpClient;
        _context = context;
    }



    private void AddToken()
    {
        var token =
            _context.HttpContext?
            .Session.GetString("token");


        if (token != null)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                token);
        }
    }



    public async Task<T?> Get<T>(string url)
    {
        AddToken();

        var response =
            await _httpClient.GetAsync(url);


        var json =
            await response.Content.ReadAsStringAsync();


        return JsonSerializer.Deserialize<T>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }




    public async Task<HttpResponseMessage> Post<T>(
        string url,
        T data)
    {
        AddToken();

        var json =
            JsonSerializer.Serialize(data);


        return await _httpClient.PostAsync(
            url,
            new StringContent(
                json,
                Encoding.UTF8,
                "application/json"));
    }



    public async Task<HttpResponseMessage> Put<T>(
        string url,
        T data)
    {
        AddToken();

        var json =
            JsonSerializer.Serialize(data);


        return await _httpClient.PutAsync(
            url,
            new StringContent(
                json,
                Encoding.UTF8,
                "application/json"));
    }



    public async Task<HttpResponseMessage> Delete(
        string url)
    {
        AddToken();

        return await _httpClient.DeleteAsync(url);
    }

}
