using ProFit.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Jobs")]
public class Job
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Requirments { get; set; }
    public int ReruiterId { get; set; }
    [ForeignKey("RecruiterId")]
    public User User { get; set; }
    public List<CV> CVs { get; set; } = new List<CV>();
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly UpdatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

}
