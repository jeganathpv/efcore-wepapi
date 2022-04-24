namespace WebApiEFCore.Prerequisite;

using System.Linq;
using WebApiEFCore.Context;
using WebApiEFCore.Models;

public class DataSeeder
{
    private readonly CompanyContext dbContext;

    public DataSeeder(CompanyContext companyContext)
    {
        this.dbContext = companyContext;
    }

    public void Seed()
    {
        if (!this.dbContext.Employees.Any())
        {
            dbContext.Employees.Add(new Employee
            {
                EmployeeName = "Jegan",
                Gender = "Male",
                DateOfBirth = "13-04-1999",
                Nationality = "Indian",
                City = "Bangalore",
                CurrentAddress = "Current Address",
                PermanentAddress = "Permanent Address",
                PinCode = "560078"
            });
            dbContext.Employees.Add(new Employee
            {
                EmployeeName = "Employee002",
                Gender = "Female",
                DateOfBirth = "01-01-1994",
                Nationality = "Indian",
                City = "Bangalore",
                CurrentAddress = "Current Address",
                PermanentAddress = "Permanent Address",
                PinCode = "560078"
            });
            dbContext.Employees.Add(new Employee
            {
                EmployeeName = "Employee003",
                Gender = "Female",
                DateOfBirth = "01-01-1995",
                Nationality = "Indian",
                City = "Bangalore",
                CurrentAddress = "Current Address",
                PermanentAddress = "Permanent Address",
                PinCode = "560078"
            });

            dbContext.SaveChanges();
        }

        if (!dbContext.Projects.Any())
        {
            dbContext.Projects.Add(new Project
            {
                Name = "D360",
                Description = "Employee Manegement",
                StartDate = new DateTime(2015, 01, 03),
                EndDate = new DateTime(2022, 01, 31),
                IsActive = true
            });

            dbContext.Projects.Add(new Project()
            {
                Name = "Analance",
                Description = "Enterprise BI Tool",
                StartDate = new DateTime(2015, 01, 03),
                IsActive = true
            });

            dbContext.Projects.Add(new Project()
            {
                Name = "MBO",
                Description = "Employee Objective Manegement",
                StartDate = new DateTime(2020, 01, 03),
                IsActive = true
            });

            dbContext.Projects.Add(new Project()
            {
                Name = "Oot",
                Description = "Socialize App",
                StartDate = new DateTime(2022, 04, 01),
                IsActive = true
            });

            dbContext.SaveChanges();
        }

        if (!dbContext.Teams.Any())
        {
            var teams = new List<Team>
            {
                new Team
                {
                    Name = "HR",
                    Description = "Human Resource"
                },
                new Team
                {
                    Name = "Product",
                    Description = "Product Team"
                },
                new Team
                {
                    Name = "Analance",
                    Description = "Emerging Markets"
                }
            };
            dbContext.Teams.AddRange(teams);
            dbContext.SaveChanges();
        }

        if (!dbContext.Users.Any())
        {
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName = "Jegan",
                    LastName =  "PV",
                    Email = "Jeganathan.Palanivel@Analance.com"
                },
                new User
                {
                    FirstName = "Dinesh",
                    LastName =  "R",
                    Email = "Dinesh.R@Analance.com"
                },
                new User
                {
                    FirstName = "Vijay",
                    LastName =  "Vadivel",
                    Email = "Vijay.Vadivel@Analance.com"
                }
            };

            dbContext.Users.AddRange(users);

            dbContext.SaveChanges();
        }
    }
}
