namespace DesafioApi.Mappers
{
    using AutoMapper;
    using DesafioApi.DTOs;
    using DesafioApi.Models;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
