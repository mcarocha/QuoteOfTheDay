using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteOfTheDay.Model
{
	public class TopicModel
	{
		public TopicModel()
		{
			TopicQuote = new List<TopicQuoteModel>();
		}
		public int Id { get; set; }
		public string TopicDescription { get; set; }
		public int ViewsCount { get; set; }
		public List<TopicQuoteModel> TopicQuote { get; set; }
	}
}
