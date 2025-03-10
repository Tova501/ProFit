using Microsoft.EntityFrameworkCore;
using ProFit.Core.Entities;
using ProFit.Core.IRepositories;
using System.Threading.Tasks;

namespace ProFit.Data.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(DataContext context) : base(context) { }

        public async Task<Job> GetJobWithCVsAsync(int jobId)
        {
            return await _context.Jobs
                .Include(j => j.CVs)
                .FirstOrDefaultAsync(j => j.Id == jobId);
        }
    }
}
