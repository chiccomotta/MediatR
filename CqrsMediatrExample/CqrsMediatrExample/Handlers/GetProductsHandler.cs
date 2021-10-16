using CqrsMediatrExample.DataStore;
using CqrsMediatrExample.Queries;
using MediatR;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatrExample.Handlers
{
	public class GetProductsHandler : 
        IRequestHandler<GetProductsQuery, IEnumerable<Product>>,
        IRequestHandler<GetProductsQuery2, IEnumerable<Product>>
	{
		private readonly FakeDataStore _fakeDataStore;

		public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
			CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetAllProducts();
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery2 request, CancellationToken cancellationToken)
        {
            Debug.WriteLine(request.Debug);
            return await _fakeDataStore.GetAllProducts();
        }
    }
}
