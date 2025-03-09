using AutoMapper;
using FluentValidation;
using ProFit.Core.DTOs;
using ProFit.Core.Entities;
using ProFit.Core.IRepositories;
using ProFit.Core.IServices;
using ProFit.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProFit.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        IMapper _mapper;
        private readonly IValidator<UserDTO> _userValidator;

        public UserService(IRepositoryManager repositoryManager, 
                            IMapper mapper,
                            IValidator<UserDTO> validator) 
        {
            _repository = repositoryManager;
            _mapper = mapper;
            _userValidator = validator;
        }

        public async Task<UserDTO> AddAsync(UserDTO user)
        {
            var validationResult = _userValidator.Validate(user);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var mappedUser = _mapper.Map<User>(user);
            var result = await _repository.Users.AddAsync(mappedUser);
            _repository.Save();
            return _mapper.Map<UserDTO>(result);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _repository.Users.GetByIdAsync(id);
            if(item == null)
            {
                throw new Exception("User not found");
            }
            return _repository.Users.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var result = await _repository.Users.GetAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var result = await _repository.Users.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(result);
        }

        public Task<UserDTO> UpdateAsync(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
