using System;
using System.Collections.Generic;

namespace QuoteOfTheDay.Data
{
	public class Quote
	{
		public Quote()
		{
			TopicQuote = new List<TopicQuote>();
		}
		public int Id { get; set; }
		public string Description { get; set; }
		public int AuthorId { get; set; }
		public Author Author { get; set; }
		public bool Displayed { get; set; }
		public DateTime RegisterDate { get; set; }
		public List<TopicQuote> TopicQuote { get; set; }
	}
}
