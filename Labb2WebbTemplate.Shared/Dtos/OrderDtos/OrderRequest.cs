namespace Labb2WebbTemplate.Api.Endpoints.Orders;

public record OrderRequest(
    int UserId, 
    IEnumerable<OrderProductRequest> Products);