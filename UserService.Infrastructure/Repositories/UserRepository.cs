using Dapper;
using Npgsql;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using UserService.Domain.Contracts.Repository;
using UserService.Domain.Entities;
using UserService.Domain.DTO;
using UserService.Domain.Enums;
using UserService.Infrastructure.DBContext;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly DapperDbContext _dapperDbContext;

        public UserRepository(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";



            int rowCountAffected = await _dapperDbContext.DbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };

            ApplicationUserDTO? userDTO = await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUserDTO>(query, parameters);

            if (userDTO == null)
            {
                return null;
            }
            else
            {
                ApplicationUser user = ApplicationUser.Map(
                    userDTO.UserID,
                    userDTO.Email,
                    userDTO.Password,
                    userDTO.PersonName,
                    userDTO.Gender
                    );
                return user;
            }

            
        }
    }
}
