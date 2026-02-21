using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Entities;
using EmployeeManagement.Data;

using EmployeeManagement.Dal.Interfaces;

namespace EmployeeManagement.Dal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext _dbContext;
        public EmployeeRepository(EmployeeManagementDbContext db) 
        { 
            _dbContext = db; 
        }
        public async Task<List<Employee>> GetAsync(string? search, int page, int pageSize)
        {
            var query = _dbContext.Set<Employee>().AsNoTracking().Where(e => !e.IsDeleted);
            var s = search?.Trim();
            if (!string.IsNullOrWhiteSpace(s))
            {
                var lowered = s.ToLower();
                query = query.Where(e => e.FullName != null && e.FullName.ToLower().Contains(lowered));
            }
            return await query.OrderBy(e => e.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> CountAsync(string? search)
        {
            var query = _dbContext.Set<Employee>().AsNoTracking().Where(e => !e.IsDeleted);
            var s = search?.Trim();
            if (!string.IsNullOrWhiteSpace(s))
            {
                var lowered = s.ToLower();
                query = query.Where(e => e.FullName != null && e.FullName.ToLower().Contains(lowered));
            }

            return await query.CountAsync();
        }
        public async Task<Employee> AddAsync(Employee employee) 
        { 
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }
        public async Task DeleteAsync(int id)
        {
            var employee = await _dbContext.Set<Employee>().FindAsync(id); 
            if (employee != null) 
            {
                employee.IsDeleted = true;
                await _dbContext.SaveChangesAsync(); 
            }
        }
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Employee>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }
    }
}
