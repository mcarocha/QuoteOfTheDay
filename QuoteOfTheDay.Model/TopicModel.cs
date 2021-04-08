using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteOfTheDay.Model
{
	public class TopicModel
	{
		public TopicModel()
		{
			Quotes = new List<QuoteModel>();
		}
		public int Id { get; set; }
		public string Description { get; set; }
		public int ViewsCount { get; set; }
		public List<QuoteModel> Quotes { get; set; }
	}
}
