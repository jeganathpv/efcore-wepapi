using WebApiEFCore.BusinessObjects;
using WebApiEFCore.Context;
using WebApiEFCore.Models;

namespace WebApiEFCore.Repository;

public class EmployeeRepository
{
    private readonly CompanyContext dbContext;

    public EmployeeRepository(CompanyContext companyContext)
    {
        this.dbContext = companyContext;
    }

    public List<Employee> GetAll()
    {
        return this.dbContext.Employees.ToList();
    }

    public Employee Get(string employeeId)
    {
        var guid = new Guid(employeeId);

        return dbContext.Employees.FirstOrDefault(x => x.EmployeeId == guid);
    }

    public Employee Add(Employee employee)
    {
        var result =  dbContext.Employees.Add(employee).Entity;
        dbContext.SaveChanges();
        return result;
    }

    public bool Delete(string employeeId)
    {
        var employee = Get(employeeId);
        if(employee != null)
        {
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
        }
        return true;
    }

    public bool Update(string employeeId, Employee employee)
    {
        var oldValue = Get(employeeId);
        if(oldValue != null)
        {
            dbContext.Entry<Employee>(oldValue).CurrentValues.SetValues(employee);
            dbContext.SaveChanges();
        }
        return true;
    }

    public List<TeamDetail> GetTeamDetails()
    {
        var result = dbContext.Employees
            .Join(
            dbContext.Projects,
            emp => emp.Project.Id,
            proj => proj.Id,
            (emp, proj) => new TeamDetail
            {
                EmployeeName = emp.EmployeeName,
                ProjectName = proj.Name,
                ProjectDescription = proj.Description,
                IsActive = proj.IsActive
            });
        return result.ToList();
    }

    public TeamDetail GetTeamDetailByEmpName(string empName)
    {
        var result = dbContext.Employees
            .Where(emp => emp.EmployeeName.ToLower() == empName.ToLower())
            .Join(
            dbContext.Projects,
            emp => emp.Project.Id,
            proj => proj.Id,
            (emp, proj) => new TeamDetail
            {
                EmployeeName = emp.EmployeeName,
                ProjectName = proj.Name,
                ProjectDescription = proj.Description,
                IsActive = proj.IsActive
            });
        return result.FirstOrDefault();
    }

    public List<TeamView> GetTeamViews()
    {
        return dbContext.TeamViews.ToList();
    }
}