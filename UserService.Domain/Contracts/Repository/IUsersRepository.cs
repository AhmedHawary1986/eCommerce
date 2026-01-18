using System.Threading.Tasks;
using UserService.Domain.Entities;

namespace UserService.Domain.Contracts.Repository
{
    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add a user to the data store and return the added user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);


        /// <summary>
        /// Method to retrieve existing user by their email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
