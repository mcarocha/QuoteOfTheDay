using Microsoft.EntityFrameworkCore;

namespace QuoteOfTheDay.Data
{
	public class QuoteOfTheDayContext: DbContext
	{

		public QuoteOfTheDayContext(DbContextOptions<QuoteOfTheDayContext> options)
			:base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Topic> Topics { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TopicQuote>().HasKey(t => new { t.QuoteId, t.TopicId });
		}
	}
}
