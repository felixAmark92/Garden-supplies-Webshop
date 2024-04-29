using System.Net.Mime;
using FastEndpoints;
using Labb2WebbTemplate.StoreDataAccess;
using Microsoft.IdentityModel.Tokens;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class AddProductImage(UnitOfWork unit) : EndpointWithoutRequest
{
    private readonly Dictionary<string, string> _supportedImageFiles  = new()
    {
        {"image/gif", ".gif"},
        {"image/png", ".png"},
        {"image/jpg", ".jpg"},
        {"image/jpeg", ".jpeg"},
        {"image/webp", ".webp"}
    };
    public override void Configure()
    {
        
        Post("image/");
        Group<ProductGroup>();
        AllowFileUploads(dontAutoBindFormData: true);
        AllowFormData();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var image = Files[0];
        var id = Form["Id"][0];
        var curDir = Environment.CurrentDirectory;

        var idParsed = int.Parse(id);

        var test2 = Directory.CreateDirectory(Path.Combine(curDir, "Images"));

        if (!_supportedImageFiles.TryGetValue(image.ContentType, out var fileExtension))
        {
            AddError(ErrorMessages.UnsupportedFileFormat(image.ContentType));
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        var fileName = id + fileExtension;
        var fullFilePath = Path.Combine(test2.FullName, fileName);
        await using var fileStream = File.Create(fullFilePath);
        
        await image.CopyToAsync(fileStream, ct);

        var product = await unit.Products.GetByIdAsync(idParsed);
        if (product is null)
        {
            throw new NullReferenceException();
        }

        product.ImagePath = fullFilePath;

        await unit.Products.UpdateAsync(idParsed, product);
        
        unit.SaveChanges();
        
        await SendOkAsync(ct);
    }
}

