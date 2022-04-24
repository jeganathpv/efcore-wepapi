namespace WebApiEFCore.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Teams")]
[Index(nameof(Name), Name = "Name_Index")]
public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TeamId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

}
