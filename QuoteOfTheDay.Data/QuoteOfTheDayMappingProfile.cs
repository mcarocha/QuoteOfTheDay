using System;
using System.Collections.Generic;
using System.Text;
using QuoteOfTheDay.Model;
using AutoMapper;

namespace QuoteOfTheDay.Data
{
	public class QuoteOfTheDayMappingProfile: Profile
	{
        public QuoteOfTheDayMappingProfile()
        {
            CreateMap<Author, AuthorModel>()
                .ReverseMap();

            CreateMap<Quote, QuoteModel>()
                 .ForMember(fm => fm.Author, opt => opt.MapFrom(a => a.Author.Name));
        }
        
    }
}
