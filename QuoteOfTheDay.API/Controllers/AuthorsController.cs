using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteOfTheDay.Data.Repositories;
using QuoteOfTheDay.Model;
using Microsoft.Extensions.Logging;
using AutoMapper;
using QuoteOfTheDay.Data;

namespace QuoteOfTheDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IRepository<Author> _repo;
        private ILogger<AuthorsController> _logger;  
        private readonly IMapper _mapper;

        public AuthorsController(IRepository<Author> repo,
          ILogger<AuthorsController> logger,
          IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            /*try
            {*/
                return Ok(_mapper.Map<IEnumerable<AuthorModel>>(_repo.All()));
            /*}
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível listar os autores: {0}", ex);
            }

            return BadRequest("Não foi possível listar os autores");*/
        }

        // GET: api/Authors/5
        [HttpGet("{id:int}")]
        public ActionResult<Author> GetAutor(int id)
        {
            //try
            {
                return Ok(_mapper.Map<AuthorModel>(_repo.Get(id)));
            }
            /*catch (Exception ex)
            {
                _logger.LogError("Não foi possível encontrar o autor: {0}", ex);
            }

            return BadRequest("Não foi possível encontrar o autor");*/
        }

        [HttpGet("{nome}")]
        public ActionResult<Author> GetAuthor(string nome)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<AuthorModel>>(_repo.Find(a => a.Name == nome)));
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível encontrar o autor: {0}", ex);
            }

            return BadRequest("Não foi possível encontrar o autor");
        }
               
        [HttpPost]
        public IActionResult Insert(AuthorModel model)
		{

            if (string.IsNullOrWhiteSpace(model.Name)) return BadRequest("O autor precisa ter um nome!");

            var autor = new Author
            {
                Name = model.Name,
                ViewCount = 0
            };

            _repo.Add(autor);
            _repo.SaveChanges();

            return Ok("Autor inserido");
        }
    }
}
