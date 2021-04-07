using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteOfTheDay.Data
{
	public class QuoteOfTheDayRepository: IQuoteOfTheDayRepository
	{
        private QuoteOfTheDayContext _context;
        
        public QuoteOfTheDayRepository(QuoteOfTheDayContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAutores()
        {
            return await _context.Authors
              .ToListAsync();
        }

        public async Task<Author> GetAuthorQuotes(int idAutor)
        {
            return await _context.Authors
              .Include(a => a.Quotes)
              //.ThenInclude(f => f.Descricao)
              .Where(a => a.Id == idAutor)
              .FirstOrDefaultAsync();
        }

        public async Task<Author> GetAuthorQuotes(string nomeAutor)
        {
            return await _context.Authors
              .Include(a => a.Quotes)
              //.ThenInclude(f => f.Descricao)
              .Where(a => a.Slug.ToLower() == nomeAutor)
              .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            return await _context.Quotes
               .Include(f => f.Author)
               .Include(f => f.TopicQuote)
               .ThenInclude(tf => tf.Topic)
              .ToListAsync();
        }
    }
}
