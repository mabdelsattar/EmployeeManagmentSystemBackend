using AutoMapper;
using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Entities;

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
