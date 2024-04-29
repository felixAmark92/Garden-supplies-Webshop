using FastEndpoints;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class GetProductImage(UnitOfWork unit)  
    : Endpoint<IdRequest, EmptyResponse>
{
    private readonly Dictionary<string, string> _supportedImageFiles  = new()
    {
        {".gif", "image/gif"},
        {".png", "image/png" },
        {".jpg", "image/jpg" },
        {".jpeg", "image/jpeg" },
        {".webp", "image/webp" }
    };
    public override void Configure()
    {
        Get("image/{id}");
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var product =  await unit.Products.GetByIdAsync(req.Id);

        if (product?.ImagePath is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var extension = Path.GetExtension(product.ImagePath);
        var mimeType = _supportedImageFiles[extension];
        
        await using var fileStream = File.OpenRead(product.ImagePath);
        await SendStreamAsync(fileStream, contentType: mimeType, cancellation: ct);
    }
}