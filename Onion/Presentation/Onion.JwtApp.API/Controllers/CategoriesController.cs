using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands;
using Onion.JwtApp.Application.Features.CQRS.Queries;

namespace Onion.JwtApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[Authorize(Roles ="Admin,Member")]
		[HttpGet]
		public async Task<IActionResult> List()
		{
			var result = await _mediator.Send(new GetCategoriesQueryRequest());
			return Ok(result);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _mediator.Send(new GetCategoryQueryRequest(id));
			return Ok(result);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
		{
			var result = await _mediator.Send(request);
			return Created("", result);
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
		{
			await _mediator.Send(request);
			return NoContent();
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			await _mediator.Send(new RemoveCategoryCommandRequest(id));
			return Ok();
		}
	}
}
