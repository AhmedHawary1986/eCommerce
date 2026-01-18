using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Enums;

namespace UserService.Domain.DTO
{
    public record RegisterRequest(
   string? Email,
   string? Password,
   string? PersonName,
   GenderOptions Gender);
}
