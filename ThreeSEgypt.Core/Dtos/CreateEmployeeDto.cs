using System;

namespace EmployeeManagement.Core.Dtos
{
    public class CreateEmployeeDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int Department { get; set; }
        public bool IsActive { get; set; }
    }
}
