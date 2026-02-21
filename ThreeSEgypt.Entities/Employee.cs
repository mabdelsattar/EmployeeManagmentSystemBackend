using System;

namespace EmployeeManagement.Entities
{
    public class Employee : BaseEntity
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public Department Department { get; set; }
        public bool IsActive { get; set; }
    }
}
