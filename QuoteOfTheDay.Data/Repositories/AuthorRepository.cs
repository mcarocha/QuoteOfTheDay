using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuoteOfTheDay.Data.Repositories
{
	public class AuthorRepository: GenericRepository<Author>
	{
		public AuthorRepository(QuoteOfTheDayContext context): base(context)
		{
			
		}

		public override Author Get(int id)
		{
			return context.Authors
				.Include(a => a.Quotes)
				.Where(a => a.Id == id)
				.FirstOrDefault();
		}

		public override IEnumerable<Author> Find(Expression<Func<Author, bool>> predicate)
		{
			return context.Authors
				.Include(a => a.Quotes)
				.Where(predicate)				
				.ToList();
		}

		public override Author Update(Author entity)
		{
			var autor = context.Authors
				.Include(a => a.Quotes)
				.Single(a => a.Id == entity.Id);

			autor.Name = entity.Name;
			autor.ViewCount = entity.ViewCount;

			return base.Update(autor);
		}
	}
}
