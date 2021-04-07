using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteOfTheDay.Data
{
	public class Author
	{
		public Author()
		{
			Quotes = new List<Quote>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public int ViewCount { get; set; }
		public List<Quote> Quotes { get; set; }

		public string Slug
		{
			get
			{
				return Name.Replace(" ", "-");
			}
		}
	}
}
