using ProFit.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class CV
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int CandidateId { get; set; }
    [ForeignKey("CandidateId")]
    public User User { get; set; }
    public int JobId { get; set; }
    [ForeignKey("JobId")]
    public Job Job { get; set; }
    public DateOnly UploadedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public int Score { get; set; }
}
