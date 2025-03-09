using ProFit.Core.Entities;
using ProFit.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Data.Reposories
{
    public class RepositoryManager(
        DataContext context, 
        IRepository<Job> jobRepository, 
        IRepository<User> userRepository, 
        IRepository<CV> cvRepository
    ) : IRepositoryManager
    {
        private readonly DataContext _context = context;
        public IRepository<Job> Jobs => jobRepository;
        public IRepository<User> Users => userRepository;
        public IRepository<CV> CVs => cvRepository;


        public async Task<int> SaveAsync()
        {
             return await _context.SaveChangesAsync();
        }
    }
}
