﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProFit.Core.Entities; 

namespace ProFit.Core.IRepositories
{
    public interface IRepositoryManager
    {
        public IJobRepository Jobs { get; }
        public IUserRepository Users { get; }
        public ICVRepository CVs { get; }

        Task<int> SaveAsync();
    }
}
