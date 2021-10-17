using MediatR;

namespace CqrsMediatrExample.Commands
{
	public record AddProductCommand(Product Product) : IRequest<Product>;
    public record AddProductCommand2(Product Product, string Type) : IRequest<Unit>;
}
