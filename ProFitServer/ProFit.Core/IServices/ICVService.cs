using ProFit.Core.DTOs;

namespace ProFit.Core.IServices
{
    public interface ICVService
    {
        Task<IEnumerable<CvDTO>> GetAllAsync();
        Task<CvDTO> GetByIdAsync(int id);
        Task<CvDTO> AddAsync(CvDTO cv);
        Task<CvDTO> UpdateAsync(int id, MemoryStream stream);
        Task DeleteAsync(int id);
    }
}