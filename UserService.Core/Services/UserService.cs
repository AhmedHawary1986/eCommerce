using System;
using System.Threading.Tasks;
using UserService.Domain.Contracts.Repository;
using UserService.Domain.Contracts.Services;
using UserService.Domain.DTO;
using UserService.Domain.Entities;
using AutoMapper;

namespace UserService.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserService(IUsersRepository usersRepository,IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                return null;

            var user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email,loginRequest.Password);
            if (user == null)
                return null;

            //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "Token", true);

            return _mapper.Map<AuthenticationResponse>(user)
            with{ Sucess = true , Token="token" };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null || string.IsNullOrEmpty(registerRequest.Email) || string.IsNullOrEmpty(registerRequest.Password))
                return null;

           

            var newUser = ApplicationUser.CreateNew(registerRequest.Email, registerRequest.Password, registerRequest.PersonName, registerRequest.Gender.ToString());
            var registeredUser = await _usersRepository.AddUser(newUser);

            if (registeredUser == null)
                return null;

            //return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "Token", true);

            return _mapper.Map<AuthenticationResponse>(registeredUser)
          with
            { Sucess = true, Token = "token" };
        }
    }
}
