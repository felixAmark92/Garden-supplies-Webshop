using FastEndpoints;
using Labb2WebbTemplate.StoreDataAccess;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Endpoints.Orders;

public class AddOrder(UnitOfWork unit) 
    : Endpoint<OrderRequest, EmptyResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(OrderRequest req, CancellationToken ct)
    {
        var user = await unit.Users.GetByIdAsync(req.UserId);
        if (user is null)
        {
            AddError(ErrorMessages.NotFound("userId", req.UserId));
            await SendNotFoundAsync(ct);
            return;
        }

        var order = new OrderEntity()
        {
            User = user,
            OrderDate = DateTime.Now
        };

        foreach (var prod in req.Products)
        {
            var product = await unit.Products.GetByIdAsync(prod.ProductId);

            if (product is null)
            {
                AddError(ErrorMessages.NotFound("ProductId", prod.ProductId));
                await SendNotFoundAsync(ct);
                return;
            }

            var productOrder = new ProductOrderEntity()
            {
                Amount = prod.Amount,
                Product = product,
                Price = product.Price
                
            };
            order.Products.Add(productOrder);
        }
        
        user.Orders.Add(order);
        
        unit.SaveChanges();

        await SendOkAsync(ct);
    }
}