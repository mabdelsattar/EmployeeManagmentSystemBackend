using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Dal.Interfaces;
using EmployeeManagement.Entities;
using AutoMapper;
using EmployeeManagement.Core.Dtos;

namespace EmployeeManagement.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetAllAsync(string? search, int page, int pageSize)
        {
            var items = await _employeeRepository.GetAsync(search, page, pageSize);
            return _mapper.Map<List<EmployeeDto>>(items);
        }

        public async Task<int> CountAsync(string? search)
        {
            return await _employeeRepository.CountAsync(search);
        }

        public async Task<EmployeeDto> AddAsync(CreateEmployeeDto dto)
        {
            var entity = _mapper.Map<Employee>(dto);
            var added = await _employeeRepository.AddAsync(entity);
            return _mapper.Map<EmployeeDto>(added);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);
            if (entity == null) return null;
            return _mapper.Map<EmployeeDto>(entity);
        }
    }
}
