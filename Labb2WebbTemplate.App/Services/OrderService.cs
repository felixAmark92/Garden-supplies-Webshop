using Labb2WebbTemplate.Api.Endpoints.Orders;

namespace Labb2WebbTemplate.App.Services;

public class OrderService
{
    private readonly HttpClient _client;

    public OrderService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("main");
    }

    public async Task<HttpResponseMessage> ConfirmOrder(OrderRequest order)
    {
        var response = await _client.PostAsJsonAsync("/order", order);

        return response;
    }

    public async Task<IEnumerable<OrderResponse>> GetUserOrders(int userId)
    {
        var response = await 
            _client.GetFromJsonAsync<IEnumerable<OrderResponse>>($"order/user/{userId}");
        return response ?? [];
    }
}