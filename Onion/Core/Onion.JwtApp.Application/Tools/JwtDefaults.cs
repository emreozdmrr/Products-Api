using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Tools
{
	public class JwtDefaults
	{
		public const string ValidAudience = "http://localhost";
		public const string ValidIssuer = "http://localhost";
		public const string Key = "emreemreemreemre.";
		public const int Expire = 5;
    }
}
