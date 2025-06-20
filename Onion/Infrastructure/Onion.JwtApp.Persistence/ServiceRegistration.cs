﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Persistence.Context;
using Onion.JwtApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContext<JwtContext>(opt =>
			{
				opt.UseSqlServer(configuration.GetConnectionString("Local"));
			});

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		}
	}
}
