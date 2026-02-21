using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

       
        [HttpGet]
        public async Task<ActionResult<PagedResult<EmployeeDto>>> Get([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var items = await _employeeService.GetAllAsync(search, page, pageSize);
            var total = await _employeeService.CountAsync(search);
            return new PagedResult<EmployeeDto> { TotalCount = total, Items = items };
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Post([FromBody] CreateEmployeeDto dto)
        {
            var added = await _employeeService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            var dto = await _employeeService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _employeeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
