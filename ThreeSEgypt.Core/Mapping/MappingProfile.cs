using AutoMapper;
using EmployeeManagement.Entities;
using EmployeeManagement.Core.Dtos;


namespace EmployeeManagement.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
        }
    }
}
