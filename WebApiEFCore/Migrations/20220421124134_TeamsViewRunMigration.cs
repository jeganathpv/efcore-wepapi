using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEFCore.Migrations
{
    public partial class TeamsViewRunMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE View TeamView as(
            Select t.Name as TeamName, e.EmployeeName, p.Name as ProjectName, p.Description, p.IsActive
            FROM Employee e
            JOIN Project p on e.ProjectId = p.Id 
            JOIN Teams t on e.TeamId = t.TeamId
            ORDER BY t.Name)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view TeamView;
        ");
        }
    }
}
