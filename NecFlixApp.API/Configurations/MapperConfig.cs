using AutoMapper;
using NecFlixApp.API.Data;
using NecFlixApp.API.Models.Categories;

namespace NecFlixApp.API.Configurations
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
        }
    }
}
