using AutoMapper;
using QuoteOfTheDay.API.Controllers;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.Data.Repositories;
using QuoteOfTheDay.Model;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace QuoteOfTheDay.Tests
{
	public class AutoresControllerTests
	{
		[SetUp]
		public void Setup()
		{
		}

        private ILogger<AuthorsController> _logger;
        private readonly IMapper _mapper;

        [Test]
        public void AddAutorTest()
        {
            // ARRANGE 
            var autorRepository = new Mock<IRepository<Author>>();

            var autoresController = new AuthorsController(
                autorRepository.Object,
                _logger,
                _mapper
            );

            var autor = new AuthorModel
            {
                Name = "Autor de Teste",
                ViewCount = 0
            };

            // ACT

            autoresController.Insert(autor);

            // ASSERT

            autorRepository.Verify(r => r.Add(It.IsAny<Author>()),
                Times.AtLeastOnce());
        }
    }
}