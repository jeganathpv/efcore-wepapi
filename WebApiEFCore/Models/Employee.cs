namespace WebApiEFCore.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Employee")]
[Index(nameof(EmployeeName), Name = "Name_Index")]
public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public string DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string CurrentAddress { get; set; }

    public string PermanentAddress { get; set; }

    public string City { get; set; }

    public string Nationality { get; set; }

    public string PinCode { get; set; }

    public string? Email { get; set; }

    public byte[]? Image { get; set; }

    [ForeignKey("ProjectId")]
    public virtual Project? Project { get; set; }

    [ForeignKey("TeamId")]
    public virtual Team? Team { get; set; }
}