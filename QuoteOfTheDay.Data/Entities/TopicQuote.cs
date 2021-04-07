using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteOfTheDay.Data
{
	public class TopicQuote
	{
		public int TopicId { get; set; }
		public int QuoteId { get; set; }
		public Topic Topic { get; set; }
		public Quote Quote { get; set; }
	}
}
