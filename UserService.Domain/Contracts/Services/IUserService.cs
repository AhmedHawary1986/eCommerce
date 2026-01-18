using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.DTO;
namespace UserService.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
        Task<AuthenticationResponse> Login (LoginRequest loginRequest);
    }
}
