using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Core.Services
{
    public class LookupService : ILookupService
    {
        public Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            var values = System.Enum.GetValues(typeof(Department))
                .Cast<Department>()
                .Select(d => new DepartmentDto { Id = (int)d, Name = d.ToString() });
            return Task.FromResult(values);
        }
    }
}
