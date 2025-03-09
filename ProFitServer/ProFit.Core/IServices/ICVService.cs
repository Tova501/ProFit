using ProFit.Core.DTOs;

namespace ProFit.Core.IServices
{
    public interface ICVService
    {
        Task<IEnumerable<CvDTO>> GetAllAsync();
        Task<CvDTO> GetByIdAsync(int id);
        Task<CvDTO> AddAsync(CvDTO cv);
        Task<CvDTO> UpdateAsync(int id, CvDTO cv);
        Task<bool> DeleteAsync(int id);
    }
}