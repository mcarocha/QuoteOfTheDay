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
	public class TopicsController : ControllerBase
	{
		private IRepository<Topic> _repo;
		private ILogger<TopicsController> _logger;
		private readonly IMapper _mapper;

		public TopicsController(IRepository<Topic> repo,
		  ILogger<TopicsController> logger,
		  IMapper mapper)
		{
			_repo = repo;
			_logger = logger;
			_mapper = mapper;
		}

		// GET: api/Topic
		[HttpGet]
		public ActionResult<IEnumerable<Topic>> GetTopics()
		{
			return Ok(_mapper.Map<IEnumerable<TopicModel>>(_repo.All()));
		}

		// GET: api/Topic/5
		[HttpGet("{id:int}")]
		public ActionResult<Topic> GetTopic(int id)
		{
			return Ok(_mapper.Map<TopicModel>(_repo.Get(id)));
		}

		[HttpGet("{nome}")]
		public ActionResult<Topic> GetTopic(string description)
		{
			return Ok(_mapper.Map<IEnumerable<TopicModel>>(_repo.Find(t => t.Description == description)));
		}				
	}
}
