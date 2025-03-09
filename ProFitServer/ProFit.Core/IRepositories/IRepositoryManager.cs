using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProFit.Core.Entities; 

namespace ProFit.Core.IRepositories
{
    public interface IRepositoryManager
    {
        public IRepository<Job> Jobs { get; }
        public IRepository<User> Users { get; }
        public IRepository<CV> CVs { get; }

        Task<int> SaveAsync();
    }
}
