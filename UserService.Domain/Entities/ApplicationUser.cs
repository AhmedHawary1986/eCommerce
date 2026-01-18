using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Contracts.Repository;
using UserService.Domain.DTO;

namespace UserService.Domain.Entities
{
    public class ApplicationUser
    {
        #region Constructors
        // For creating a new domain user (assigns new Id)
        public ApplicationUser(string email, string password, string? personName = null, string? gender = null)
        {
            UserID = Guid.NewGuid();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            PersonName = personName;
            Gender = gender;
        }

        public ApplicationUser(Guid userId,string email, string password, string? personName = null, string? gender = null)
        {
            UserID = userId;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            PersonName = personName;
            Gender = gender;
        }

        // Parameterless ctor for ORMs/deserializers

        #endregion

        #region Properties
        public Guid UserID { get; private set; }
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!; // store hashed password in production
        public string? PersonName { get; private set; }
        public string? Gender { get; private set; }
        #endregion

        #region Methods
        public bool VerifyPassword(string password)
        {
            // Replace with secure hash comparison in production
            return Password == password;
        }

        public void ChangePassword(string currentPassword, string newPassword)
        {
            if (!VerifyPassword(currentPassword))
                throw new InvalidOperationException("Current password is incorrect.");

            Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
        }

        public void UpdateProfile(string? personName, string? gender)
        {
            PersonName = personName;
            Gender = gender;
        }

        // Factory helper used by application/service layer when registering a user
        public static ApplicationUser CreateNew(string email, string password, string? personName = null, string? gender = null)
            => new ApplicationUser(email, password, personName, gender);

        public static ApplicationUser Map(Guid userId,string email, string password, string? personName = null, string? gender = null)
          => new ApplicationUser(userId,email, password, personName, gender);
        #endregion
    }
}
