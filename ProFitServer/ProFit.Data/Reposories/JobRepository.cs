using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using ProFit.Core.Entities;
using ProFit.Core.IRepositories;
using ProFit.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Data.Reposories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(DataContext dataContex) : base(dataContex)
        {
        }
        public async Task<List<Job>> GetJobsAsync()
        {
            return await _dbSet.Include(x => x.CVs).ToListAsync();
        }
    }
}
