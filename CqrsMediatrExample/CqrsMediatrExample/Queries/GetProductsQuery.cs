using MediatR;
using System.Collections.Generic;

namespace CqrsMediatrExample.Queries
{
	public record GetProductsQuery : IRequest<IEnumerable<Product>>;

    public class GetProductsQuery2: IRequest<IEnumerable<Product>>
    {
        public string Debug { get; } = "test debug string";
    }
}
