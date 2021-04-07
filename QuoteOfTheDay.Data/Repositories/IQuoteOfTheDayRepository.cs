using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuoteOfTheDay.Data
{
	public interface IQuoteOfTheDayRepository
	{

        Task<IEnumerable<Author>> GetAutores();
        Task<Author> GetAuthorQuotes(int idAutor);
        Task<Author> GetAuthorQuotes(string nomeAutor);        

        Task<IEnumerable<Quote>> GetQuotes();

    }
}
