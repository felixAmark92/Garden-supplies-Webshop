using Labb2WebbTemplate.Api.Endpoints.Orders;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Extensions;

public static class OrderEntityExtensions
{
    public static OrderResponse ToOrderResponse(this OrderEntity order)
    {
        return new OrderResponse(
            order.Id,
            order.OrderDate,
            order.Products.Select(p =>
                new OrderProductResponse(
                    p.ProductId,
                    p.Product.Name,
                    p.Price,
                    p.Amount)));
    }
}