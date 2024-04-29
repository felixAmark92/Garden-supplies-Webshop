namespace Labb2WebbTemplate.Api.Endpoints.Orders;

public record OrderResponse(
    int Id, 
    DateTime Date, 
    IEnumerable<OrderProductResponse> Products
);

