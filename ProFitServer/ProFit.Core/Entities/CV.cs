using ProFit.Core.Entities;

public class CV
{
    public int Id { get; set; }
    public string Path { get; set; }
    public int UserId { get; set; } 
    public User User { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; }
    public DateTime UploadedDate { get; set; }
    public int Score { get; set; }
}
