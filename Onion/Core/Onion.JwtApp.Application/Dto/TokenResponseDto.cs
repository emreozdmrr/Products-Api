﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Dto
{
	public class TokenResponseDto
	{
		public TokenResponseDto(string token, DateTime expireDate)
		{
			Token = token;
			ExpireDate = expireDate;
		}

		public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
