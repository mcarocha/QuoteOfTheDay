using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuoteOfTheDay.Model
{
	public class AuthorModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ViewCount { get; set; }
		public List<QuoteModel> Quotes { get; set; }

	}
}
