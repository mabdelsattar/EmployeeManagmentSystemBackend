using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        [HttpGet("departments")]
        public ActionResult<IEnumerable<object>> GetDepartments()
        {
            var values = Enum.GetValues(typeof(Department)).Cast<Department>().Select(d => new { Id = (int)d, Name = d.ToString() });
            return Ok(values);
        }
    }
}
