using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuoteOfTheDay.Data.Repositories
{
	public class TopicRepository: GenericRepository<Topic>
	{
		public TopicRepository(QuoteOfTheDayContext context): base(context)
		{
			
		}

		public override Topic Get(int id)
		{
			return context.Topics
				.Include(t => t.TopicQuote)
				.ThenInclude(tp => tp.Quote)
				.Where(t => t.Id == id)
				.FirstOrDefault();
		}

		public override IEnumerable<Topic> Find(Expression<Func<Topic, bool>> predicate)
		{
			return context.Topics
				.Include(t => t.TopicQuote)
				.ThenInclude(tp => tp.Quote)
				.Where(predicate)				
				.ToList();
		}

		public override Topic Update(Topic entity)
		{
			var topic = context.Topics
				.Include(t => t.TopicQuote)
				.ThenInclude(tp => tp.Quote)
				.Single(t => t.Id == entity.Id);

			topic.Description = entity.Description;
			topic.ViewsCount = entity.ViewsCount;

			return base.Update(topic);
		}
	}
}
