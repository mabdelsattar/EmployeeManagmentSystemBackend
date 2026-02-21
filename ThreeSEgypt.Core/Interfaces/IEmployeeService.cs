using EmployeeManagement.Entities;
using EmployeeManagement.Core.Dtos;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync(string? search, int page, int pageSize);
        Task<int> CountAsync(string? search);
        Task<EmployeeDto> AddAsync(CreateEmployeeDto dto);
        Task DeleteAsync(int id);
        Task<EmployeeDto?> GetByIdAsync(int id);
    }
}
