namespace WebApiEFCore.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Project")]
public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

}