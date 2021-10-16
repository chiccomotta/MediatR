﻿using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Notifications;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CqrsMediatrExample.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator) => _mediator = mediator;

		[HttpGet]
		[Route("GetProducts")]
		public async Task<ActionResult> GetProducts()
		{
			var products = await _mediator.Send(new GetProductsQuery());
            var products2 = await _mediator.Send(new GetProductsQuery2());

            return Ok(products2);
        }

		[HttpGet("{id:int}", Name = "GetProductById")]
		public async Task<ActionResult> GetProductById(int id)
		{
			var product = await _mediator.Send(new GetProductByIdQuery(id));

			return Ok(product);
		}

		[HttpPost]
		[Route("AddProduct")]
		public async Task<ActionResult> AddProduct([FromBody]Product product)
		{
			var productToReturn = await _mediator.Send(new AddProductCommand(product));

			await _mediator.Publish(new ProductAddedNotification(productToReturn));

			return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
		}
	}
}
