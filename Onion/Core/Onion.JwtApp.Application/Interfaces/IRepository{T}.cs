﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Interfaces
{
	public interface IRepository<T> where T : class, new()
	{
		Task<List<T>> GetAllAsync();
		Task<T?> GetByIdAsync(object id);
		Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
		Task<T?> CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task Remove(T entity);
		Task<int> SaveChangesAsync();
	}
}
