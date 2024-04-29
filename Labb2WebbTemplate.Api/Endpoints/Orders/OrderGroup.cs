using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.Orders;

public sealed class OrderGroup : Group
{
    public OrderGroup()
    {
        Configure("/order", definition => definition.AllowAnonymous());
    }
}