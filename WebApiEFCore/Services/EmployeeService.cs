using WebApiEFCore.BusinessObjects;
using WebApiEFCore.Models;
using WebApiEFCore.Repository;

namespace WebApiEFCore.Services;

public class EmployeeService
{
    private readonly EmployeeRepository employeeRepository;
    public EmployeeService(EmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public List<Employee> GetEmployees()
    {
        return this.employeeRepository.GetAll();
    }

    public Employee GetEmployee(string id)
    {
        return this.employeeRepository.Get(id);
    }

    public Employee AddEmployee(Employee employee)
    {
        return this.employeeRepository.Add(employee);
    }

    public List<TeamDetail> GetTeamDetails()
    {
        return this.employeeRepository.GetTeamDetails();
    }

    public TeamDetail GetTeamDetailOfEmployee(string name)
    {
        return this.employeeRepository.GetTeamDetailByEmpName(name);
    }

    public List<TeamView> GetTeamViews()
    {
        return this.employeeRepository.GetTeamViews();
    }
}
