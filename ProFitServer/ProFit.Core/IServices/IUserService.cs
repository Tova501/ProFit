using ProFit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Core.IServices
{
    public interface IUserService { 
        public Task<List<User>> getallAsync();
        public Task<User> getByIdAsync(int id);
        public Task<User> addAsync(User user);
        public Task<User> updateAsync(int id, User user);
        public Task<bool> deleteAsync(int id);
    }
}
