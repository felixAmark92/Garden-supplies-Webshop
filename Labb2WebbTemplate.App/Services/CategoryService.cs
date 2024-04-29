using Labb2WebbTemplate.Shared.Dtos.CategoryDtos;
using StringContent = System.Net.Http.StringContent;

namespace Labb2WebbTemplate.App.Services;

public class CategoryService(IHttpClientFactory clientFactory)
{
    private readonly HttpClient _client = clientFactory.CreateClient("main");
    public async Task<IEnumerable<CategoryResponse>> GetCategories()
    {
        var response = await _client.GetFromJsonAsync<IEnumerable<CategoryResponse>>("/category");

        return response ?? [];
    }

    public async Task AddCategory(string category)
    {
        var response = await _client.PostAsJsonAsync("/category",category);
    }
    
}