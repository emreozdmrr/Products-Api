﻿using AutoMapper;
using Onion.JwtApp.Application.Dto;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Mappings
{
	public class CategoryProfile : Profile
	{
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
            this.CreateMap<Category, CreatedCategoryDto>().ReverseMap();
        }
    }
}
