using FastEndpoints;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Orders;

public class GetOrderById(UnitOfWork unit) : Endpoint<IdRequest, OrderResponse>
{
    public override void Configure()
    {
        Get("/id/{id}");
        
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var order = await unit.Orders.GetByIdAsync(req.Id);

        if (order is null)
        {
            AddError(ErrorMessages.NotFound("id", req.Id));
            await SendNotFoundAsync(ct);
            return;
        }

        var response = order.ToOrderResponse();
        await SendOkAsync(response, ct);
    }
}