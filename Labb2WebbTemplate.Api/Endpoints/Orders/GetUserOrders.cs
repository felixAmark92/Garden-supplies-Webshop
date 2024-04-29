using FastEndpoints;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.Api.Endpoints.User;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Orders;

public class GetUserOrders(UnitOfWork unit) : Endpoint<IdRequest, IEnumerable<OrderResponse>>
{
    public override void Configure()
    {
        Get("/user/{id}");
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var orders = await unit.Orders.GetOrdersByUserId(req.Id);

        if (orders is null)
        {
            AddError(ErrorMessages.NotFound("Id",req.Id));

            await SendErrorsAsync(cancellation: ct);
            return;
        }

        var response = orders.Select(o => o.ToOrderResponse());

        await SendOkAsync(response, ct);
    }

}


