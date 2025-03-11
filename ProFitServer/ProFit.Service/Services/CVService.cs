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
    public class CVService : ICVService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public CVService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CvDTO> AddAsync(CvDTO cv)
        {
            var newCV = _mapper.Map<CV>(cv);
            //uploading the CV
            newCV.UploadedDate = DateTime.Now;
            await _repositoryManager.CVs.AddAsync(newCV);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<CvDTO>(cv);
        }

        public async Task DeleteAsync(int id)
        {
            var cv = await _repositoryManager.CVs.GetByIdAsync(id);
            if (cv == null)
            {
                throw new Exception("not found");
            }
            _repositoryManager.CVs.DeleteAsync(cv);
            await _repositoryManager.SaveAsync();
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

        public async Task<CvDTO> UpdateAsync(int id, MemoryStream stream)
        {
            throw new Exception("Not Implemnted");
        }
    }
}
