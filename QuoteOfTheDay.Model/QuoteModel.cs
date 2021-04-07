using System;
using System.Collections.Generic;

namespace QuoteOfTheDay.Model
{
	public class QuoteModel
	{
		public QuoteModel()
		{
			TopicQuotes = new List<TopicQuoteModel>();
		}
		public int Id { get; set; }
		public string Description { get; set; }
		public int AuthorId { get; set; }
		public string Author { get; set; }
		public bool Displayed { get; set; }
		public DateTime RegisterDate { get; set; }
		public List<TopicQuoteModel> TopicQuotes { get; set; }
	}
}
