using EmployeeManagement.Core.Dtos;

namespace EmployeeManagement.Core.Interfaces
{
    public interface ILookupService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
    }
}
