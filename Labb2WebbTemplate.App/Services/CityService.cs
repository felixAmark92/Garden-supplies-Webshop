using System.Net;
using Labb2WebbTemplate.Shared.Dtos.CityDtos;
using Labb2WebbTemplate.Shared.Enums;

namespace Labb2WebbTemplate.App.Services;

//TODO: change to model?
public class CityService(IHttpClientFactory clientFactory)
{
    private readonly HttpClient _client = clientFactory.CreateClient("main");
    
    public async Task<CityResponse?> GetByIdAsync(int id)
    {
        var request = await _client.GetFromJsonAsync<CityResponse>($"city/id/{id}");

        return request;
    }

    public async Task<IEnumerable<CityResponse>> GetAllAsync()
    {
        var request = await _client.GetFromJsonAsync<IEnumerable<CityResponse>>("/city");

        return request ?? [];

    }

    public async Task<HttpStatusCode> AddAsync(CityRequest cityRequest)
    {
        var request = await _client.PostAsJsonAsync("/city/", cityRequest);

        return request.StatusCode;
    }

    public async Task<RepositoryStatus> UpdateAsync(int id, CityResponse newEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<RepositoryStatus> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}