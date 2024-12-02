﻿using AutoMapper;
using MyWebWithEF.BLL.Components.CategoryComponent.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Мапінг для Idea
        CreateMap<Idea, IdeaDto>().ReverseMap();

        // Мапінг для Category
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
