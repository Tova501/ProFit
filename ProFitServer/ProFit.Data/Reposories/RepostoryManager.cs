﻿using ProFit.Core.Entities;
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
        IJobRepository jobRepository, 
        IUserRepository userRepository, 
        ICVRepository cvRepository
    ) : IRepositoryManager
    {
        private readonly DataContext _context = context;
        public IJobRepository Jobs => jobRepository;
        public IUserRepository Users => userRepository;
        public ICVRepository CVs => cvRepository;


        public async Task<int> SaveAsync()
        {
             return await _context.SaveChangesAsync();
        }
    }
}
