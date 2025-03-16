using AutoMapper;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using ProFit.API.PostModels;
using ProFit.Core.DTOs;
using ProFit.Core.Entities;
using ProFit.Core.IServices;

namespace ProFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IValidator<UserDTO> _registerValidator;
        public AuthController(
            IConfiguration configuration, 
            IUserService userService, 
            IMapper mapper,
            IValidator<UserDTO> validator)
        {
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
            _registerValidator = validator;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel loginModel)
        {
            var res = await _userService.LoginAsync(loginModel.Email, loginModel.Password);
            if (res == null)
                return NotFound();
            if (res.IsActive == false)
                return Unauthorized();

            var tokenString = _authService.GenerateJwtToken(res.Name, res.Roles.Select(r => r.RoleName).ToArray());
            return Ok(new { Token = tokenString, user = res });
        }

        // POST api/<UserController>

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserPostModel userRegister)
        {
            var user = _mapper.Map<User>(userRegister);
            var userDTO = _mapper.Map<UserDTO>(user);
            var validationResults = _registerValidator.Validate(userDTO);
            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var res = await _userService.RegisterAsync(_mapper.Map<UserDto>(userRegister.User), userRegister.Roles);
            if (res == null)
            {
                return BadRequest();
            }

            var tokenString = _authService.GenerateJwtToken(res.Name, userRegister.Roles);
            return Ok(new { Token = tokenString, user = res });
        }
    }
}

