using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.DTO
{
    public class ApplicationUserDTO
    {
        public Guid UserID { get;  set; }
        public string Email { get;  set; } = null!;
        public string Password { get;  set; } = null!; // store hashed password in production
        public string? PersonName { get;  set; }
        public string? Gender { get;  set; }
    }
}
