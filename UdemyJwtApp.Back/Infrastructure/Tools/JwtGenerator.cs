﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UdemyJwtApp.Back.Core.Application.Dto;

namespace UdemyJwtApp.Back.Infrastructure.Tools
{
	public class JwtGenerator
	{
		public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
		{
			var claims = new List<Claim>();

			if (!string.IsNullOrEmpty(dto.Role))
				claims.Add(new Claim(ClaimTypes.Role, dto.Role));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));
			if (!string.IsNullOrEmpty(dto.Username))
				claims.Add(new Claim("Username", dto.Username));

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtDefaults.Key));

			SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var expireDate = DateTime.UtcNow.AddMinutes(JwtDefaults.Expire);
			
			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
				issuer: JwtDefaults.ValidIssuer, audience: JwtDefaults.ValidAudience,
				claims: claims, notBefore: DateTime.UtcNow,
				expires: DateTime.UtcNow.AddMinutes(JwtDefaults.Expire),
				signingCredentials: credentials);

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return new TokenResponseDto(handler.WriteToken(jwtSecurityToken), expireDate);
		}
	}
}
