using ProFit.Core.Entities;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Requirments { get; set; }
    public int UserId { get; set; } 
    public User User { get; set; }
    public List<CV> CVs { get; set; }
    public DateTime Created { get; set; }
}
