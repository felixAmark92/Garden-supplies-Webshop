using System.Net;
using Labb2WebbTemplate.Shared.Dtos.RegionDtos;
using Labb2WebbTemplate.Shared.Enums;

namespace Labb2WebbTemplate.App.Services;

public class RegionService(IHttpClientFactory clientFactory)
{
    private readonly HttpClient _client = clientFactory.CreateClient("main");
    
    public async Task<RegionResponse?> GetByIdAsync(int id)
    {
        var request = await _client.GetAsync($"/region/id/{id}");

        return await request.Content.ReadFromJsonAsync<RegionResponse>();
    }

    public async Task<IEnumerable<RegionResponse>> GetAllAsync()
    {
         var request = await _client.GetAsync($"/region/");

         var result = await request.Content.ReadFromJsonAsync<IEnumerable<RegionResponse>>();
        return result ?? [];
    }

    public async Task<HttpStatusCode> AddAsync(string region)
    {
        var request = await _client.PostAsJsonAsync("/region/", region);

        return request.StatusCode;
    }

    public async Task<RepositoryStatus> UpdateAsync(int id, RegionResponse newEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<RepositoryStatus> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}