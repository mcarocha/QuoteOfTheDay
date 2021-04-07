using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteOfTheDay.Data
{
	public class Topic
	{
		public Topic()
		{
			TopicQuote = new List<TopicQuote>();
		}
		public int Id { get; set; }
		public string Description { get; set; }
		public int ViewsCount { get; set; }
		public List<TopicQuote> TopicQuote { get; set; }
	}
}
