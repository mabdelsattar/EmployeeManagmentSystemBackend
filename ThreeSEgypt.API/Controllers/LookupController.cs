using EmployeeManagement.API.Models;
using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var items = await _lookupService.GetDepartmentsAsync();
            return Ok(items);
        }
    }
}
