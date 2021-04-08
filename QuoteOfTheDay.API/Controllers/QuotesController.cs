using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.Model;
using Microsoft.Extensions.Logging;
using AutoMapper;
using QuoteOfTheDay.Data.Repositories;

namespace QuoteOfTheDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteOfTheDayContext _context;
        private IRepository<Quote> _repo;
        private ILogger<QuotesController> _logger;
        private readonly IMapper _mapper;

        public QuotesController(IRepository<Quote> repo,
          ILogger<QuotesController> logger, QuoteOfTheDayContext context,
          IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetQuotes()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<QuoteModel>>(_repo.All()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível listar as frases: {0}", ex);
            }

            return BadRequest("Não foi possível listar as frases");
        }

        [HttpGet("{topic}")]
        public ActionResult<List<Quote>> GetQuotes(string topic)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<QuoteModel>>(_repo.Find(q => q.TopicQuote.Select(tp => tp.Topic.Description).Contains(topic))));
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível encontrar o autor: {0}", ex);
            }

            return BadRequest("Não foi possível encontrar o autor");
        }

        // PUT: api/Frases/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotes(int id, Quote frase)
        {
            if (id != frase.Id)
            {
                return BadRequest();
            }

            _context.Entry(frase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Frases
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuotes(Quote frase)
        {
            _context.Quotes.Add(frase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrase", new { id = frase.Id }, frase);
        }

        // DELETE: api/Frases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> DeleteQuote(int id)
        {
            var frase = await _context.Quotes.FindAsync(id);
            if (frase == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(frase);
            await _context.SaveChangesAsync();

            return frase;
        }

        private bool QuoteExist(int id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }
    }
}
