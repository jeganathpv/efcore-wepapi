using Microsoft.AspNetCore.Mvc;
using WebApiEFCore.BusinessObjects;
using WebApiEFCore.Models;
using WebApiEFCore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return this._employeeService.GetEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(string id)
        {
            return this._employeeService.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {
            return this._employeeService.AddEmployee(value);
        }

        [HttpGet("projectDetails")]
        public List<TeamDetail> GetTeamDetails()
        {
            return this._employeeService.GetTeamDetails();
        }

        [HttpGet("projectDetail/{empName}")]
        public TeamDetail GetTeamDetailOfEmp(string empName)
        {
            return this._employeeService.GetTeamDetailOfEmployee(empName);
        }

        [HttpGet("teamDetails")]
        public List<TeamView> GetTeamViews()
        {
            return this._employeeService.GetTeamViews();
        }
    }
}
