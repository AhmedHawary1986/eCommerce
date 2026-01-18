using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserService.Domain.DTO;

namespace UserService.Domain.Enums
{
    [JsonConverter(typeof(SafeGenderConverter))]
    public enum GenderOptions
    {
        Unknown=0,Male=1, Female=2
    }
}
