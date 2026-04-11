using Catalog.API.Models;
using Common.CQRS;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Categories,
    string Description,
    string Image,
    decimal Price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand cmd,
        CancellationToken cancellationToken
    )
    {
        var product = new Product
        {
            Name = cmd.Name,
            Categories = cmd.Categories,
            Description = cmd.Description,
            Image = cmd.Image,
            Price = cmd.Price,
        };

        return new CreateProductResult(Guid.NewGuid());
    }
}
