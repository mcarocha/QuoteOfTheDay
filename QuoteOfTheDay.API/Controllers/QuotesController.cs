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

namespace QuoteOfTheDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteOfTheDayContext _context;
        private IQuoteOfTheDayRepository _repo;
        private ILogger<QuotesController> _logger;
        private readonly IMapper _mapper;

        public QuotesController(IQuoteOfTheDayRepository repo,
          ILogger<QuotesController> logger, QuoteOfTheDayContext context,
          IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetFrases()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<QuoteModel>>(await _repo.GetQuotes()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível listar as frases: {0}", ex);
            }

            return BadRequest("Não foi possível listar as frases");
        }

        // PUT: api/Frases/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrase(int id, Quote frase)
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
                if (!FraseExists(id))
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
        public async Task<ActionResult<Quote>> PostFrase(Quote frase)
        {
            _context.Quotes.Add(frase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrase", new { id = frase.Id }, frase);
        }

        // DELETE: api/Frases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> DeleteFrase(int id)
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

        private bool FraseExists(int id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }
    }
}
