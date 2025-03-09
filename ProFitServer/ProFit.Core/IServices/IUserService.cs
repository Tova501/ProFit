using ProFit.Core.DTOs;
using ProFit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.IServices
{
    public interface IUserService { 
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> AddAsync(UserDTO user);
        Task<UserDTO> UpdateAsync(int id, UserDTO user);
        Task<bool> DeleteAsync(int id);
    }
}
