﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuoteOfTheDay.Data.Repositories
{
	public abstract class GenericRepository<T>
		: IRepository<T> where T : class
	{
		protected QuoteOfTheDayContext context;

		public GenericRepository(QuoteOfTheDayContext context)
		{
			this.context = context;
		}

		public virtual T Add(T entity)
		{
			return context.Add(entity).Entity;
		}

		public virtual IEnumerable<T> All()
		{
			return context.Set<T>()
				.ToList();
		}

		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return context.Set<T>()
				.AsQueryable()
				.Where(predicate)
				.ToList();
		}

		public virtual T Get(int id)
		{
			return context.Find<T>(id);
		}

		public virtual void SaveChanges()
		{
			context.SaveChanges();
		}

		public virtual T Update(T entity)
		{
			return context.Update(entity).Entity;
		}
	}
}
