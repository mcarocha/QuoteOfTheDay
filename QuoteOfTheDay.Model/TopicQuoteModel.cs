using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteOfTheDay.Model
{
	public class TopicQuoteModel
	{
		public int TopicId { get; set; }
		public int QuoteId { get; set; }
		public TopicModel Topic { get; set; }
		public QuoteModel Quote { get; set; }
	}
}
