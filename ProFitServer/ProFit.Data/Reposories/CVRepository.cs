using Microsoft.EntityFrameworkCore;
using ProFit.Core.Entities;
using ProFit.Core.IRepositories;
using System.Threading.Tasks;

namespace ProFit.Data.Repositories
{
    public class CVRepository : Repository<CV>, ICVRepository
    {
        public CVRepository(DataContext context) : base(context) { }

        public Task<IEnumerable<CV>> GetCVsWithJobAsync()
        {
            throw new NotImplementedException();
        }

    }
}
