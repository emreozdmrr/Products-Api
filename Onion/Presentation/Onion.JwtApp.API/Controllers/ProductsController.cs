using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands;
using Onion.JwtApp.Application.Features.CQRS.Handlers;
using Onion.JwtApp.Application.Features.CQRS.Queries;
using System.Runtime.CompilerServices;

namespace Onion.JwtApp.API.Controllers
{
	[Authorize(Roles ="Admin,Member")]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator mediator;

		public ProductsController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var result = await this.mediator.Send(new GetProductsQueryRequest());
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await this.mediator.Send(new GetProductQueryRequest(id));
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductCommandRequest request)
		{
			var result = await mediator.Send(request);
			return Created("", result);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateProductCommandRequest request)
		{
			await this.mediator.Send(request);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			await this.mediator.Send(new RemoveProductCommandRequest(id));
			return Ok();
		}
	}
}
