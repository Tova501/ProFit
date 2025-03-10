﻿using AutoMapper;
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
    class CVService : ICVService
    {
        private readonly Mapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public CVService(IRepositoryManager repositoryManager, Mapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CvDTO> AddAsync(CvDTO cv)
        {
            var newCV = _mapper.Map<CV>(cv);
            _repositoryManager.CVs.AddAsync(newCV);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<CvDTO>(cv);
        }

        public Task<bool> DeleteAsync(int id)
        { 
            return _repositoryManager.CVs.DeleteAsync(id);
        }

        public async Task<IEnumerable<CvDTO>> GetAllAsync()
        {
            var cvList = await _repositoryManager.CVs.GetAsync();
            return _mapper.Map<IEnumerable<CvDTO>>(cvList);
        }

        public async Task<CvDTO> GetByIdAsync(int id)
        {
            var item = _repositoryManager.CVs.GetByIdAsync(id);
            return _mapper.Map<CvDTO>(item);
        }

        public async Task<CvDTO> UpdateAsync(int id, CvDTO cv)
        {
            var item = _mapper.Map<CV>(cv);
            var updated = await _repositoryManager.CVs.UpdateAsync(id, item);
            return _mapper.Map<CvDTO>(updated);
        }
    }
}
