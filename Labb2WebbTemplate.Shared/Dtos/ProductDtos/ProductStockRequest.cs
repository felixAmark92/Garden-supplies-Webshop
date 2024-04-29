namespace Labb2WebbTemplate.Api.Endpoints.Product;

public record ProductStockRequest(
    int ProductId, 
    int Amount);