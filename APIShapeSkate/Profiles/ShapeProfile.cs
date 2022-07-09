using APIShapeSkate.Data.Dtos;
using AutoMapper;
using APIShapeSkate.Data;

namespace APIShapeSkate.Profiles
{
    public class ShapeProfile : Profile
    {
        public ShapeProfile()
        {
            CreateMap<CreateShapeDto, Shape>();
            CreateMap<Shape, ReadShapeDto>();
            CreateMap<UpdateShapeDto, Shape>();
        }
    }

}
