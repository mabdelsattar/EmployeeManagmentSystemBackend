using System.Collections.Generic;

namespace EmployeeManagement.Core.Dtos
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
