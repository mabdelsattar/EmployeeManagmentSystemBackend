using EmployeeManagement.Entities;

namespace EmployeeManagement.Dal.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAsync(string? search, int page, int pageSize);
        Task<int> CountAsync(string? search);
        Task<Employee> AddAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<Employee?> GetByIdAsync(int id);
    }
}
