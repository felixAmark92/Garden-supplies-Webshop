namespace Labb2WebbTemplate.Api.Endpoints.Orders;

public record OrderProductResponse(
    int Id, 
    string Name, 
    double Price, 
    int Amount
);
