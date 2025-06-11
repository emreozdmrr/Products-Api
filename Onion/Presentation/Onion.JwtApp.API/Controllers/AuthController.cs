using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands;
using Onion.JwtApp.Application.Features.CQRS.Queries;
using Onion.JwtApp.Application.Tools;

namespace Onion.JwtApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator mediator;

		public AuthController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Login(CheckUserQueryRequest request)
		{
			var dto = await this.mediator.Send(request);
			if (dto.IsExist)
			{
				return Created("", JwtGenerator.GenerateToken(dto));
			}
			else
			{
				return BadRequest("Kullanıcı adı veya şifre hatalı");
			}
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Register(RegisterUserCommandRequest request)
		{
			var result = await this.mediator.Send(request);
			return Created("", result);
		}
	}
}
