using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QuoteOfTheDay.Data.Repositories
{
	public class QuoteRepository: GenericRepository<Quote>
	{
		public QuoteRepository(QuoteOfTheDayContext context): base(context)
		{
			
		}

		public override IEnumerable<Quote> All()
		{
			return context.Quotes
				.Include(f => f.Author)
				.Include(f => f.TopicQuote)
				.ThenInclude(tf => tf.Topic)
				.ToList(); ;
		}

		public override IEnumerable<Quote> Find(Expression<Func<Quote, bool>> predicate)
		{
			return context.Quotes
				.Include(f => f.Author)
			    .Include(f => f.TopicQuote)
			    .ThenInclude(tf => tf.Topic)
				.Where(predicate)				
				.ToList();
		}
				
	}
}
