using AutoMapper;
using ProFit.Core.DTOs;
using ProFit.Core.Entities;
using ProFit.Core.IRepositories;
using ProFit.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Service.Services
{
    public class JobService : IJobService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public JobService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }   
        public Task<JobDTO> AddAsync(JobDTO job)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _repository.Jobs.GetByIdAsync(id);
            if (item == null)
            {
                throw new Exception("User Not Found");
            }
             _repository.Jobs.DeleteAsync(item);
        }

        public async Task<IEnumerable<JobDTO>> GetAllAsync()
        {
            var jobs = await _repository.Jobs.GetAsync();
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }

        public async Task<JobDTO> GetByIdAsync(int id)
        {
            var job = await _repository.Jobs.GetByIdAsync(id);
            return _mapper.Map<JobDTO>(job);
        }

        public async Task<List<CV>> GetCVsByJobId(int id)
        {
            var job = await _repository.Jobs.GetJobWithCVsAsync(id);
            return job.CVs.ToList();
        }

        public Task<JobDTO> UpdateAsync(int id, JobDTO job)
        {
            throw new NotImplementedException();
        }
    }
}
