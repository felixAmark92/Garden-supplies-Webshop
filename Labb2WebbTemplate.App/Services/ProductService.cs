using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.App.Components.Pages.CustomComponents;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Primitives;
using MudBlazor;

namespace Labb2WebbTemplate.App.Services;

public class ProductService(IHttpClientFactory clientFactory)
{
    private readonly HttpClient _client = clientFactory.CreateClient("main");

    public async Task<ProductResponse?> GetProductById(int id)
    {
        var response = await _client.GetFromJsonAsync<ProductResponse>($"/Product/id/{id}");

        return response;
    }

    public async Task<Stream?> GetProductImage(int productId)
    {
        var response = await _client.GetAsync($"/product/image/{productId}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
        
        return await response.Content.ReadAsStreamAsync();
    }
    
    public async Task<IEnumerable<ProductResponse>> GetProducts()
    {
        var response = await _client.GetFromJsonAsync<IEnumerable<ProductResponse>>("/product");

        return response ?? [];
    }

    public async Task<HttpResponseMessage> AddProduct(ProductRequest product)
    {
        var result = await _client.PostAsJsonAsync("/product", product);

        return result;
    }
    public async Task<HttpResponseMessage> UpdateProduct(ProductRequest newProduct)
    {
        var result = await _client.PatchAsJsonAsync("/product", newProduct);
        return result;
    }

    public async Task<HttpStatusCode> AddToStock(int amount, int productId)
    {
        var request = new ProductStockRequest(productId, amount);
        var result = await _client.PatchAsJsonAsync("/product/addToStock", request);

        return result.StatusCode;
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsByCategory(int id)
    {
        var result = await _client.GetFromJsonAsync<IEnumerable<ProductResponse>>($"/product/category/{id}");
        return result ?? [];
    }

    public async Task<HttpResponseMessage> AddProductImage(int id, IBrowserFile imageFile)
    {
        using var content = new MultipartFormDataContent();

        await using var stream = imageFile.OpenReadStream();
        
        content.Add(
            new StreamContent(stream)
                {Headers = { ContentType = new MediaTypeHeaderValue(imageFile.ContentType)}}, 
            "ImageFile", 
            imageFile.Name);
        
        content.Add(new StringContent(id.ToString()), "Id");

        var result = await _client.PostAsync("/product/image/", content);

        return result;
    }


    public async Task<HttpResponseMessage> DeleteProduct(int productId)
    {
        var result = await _client.DeleteAsync($"/product/id/{productId}");
        return result;
    }
}
