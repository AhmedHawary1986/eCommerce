using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using UserService.Domain.DTO;
using UserService.Domain.Enums;

namespace UserService.Domain.DTO
{
    public class SafeGenderConverter : JsonConverter<GenderOptions>
    {
        public override GenderOptions Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();

                if (Enum.TryParse<GenderOptions>(value, true, out var gender))
                    return gender;
            }

            // Default value that FluentValidation can catch
            return default;
        }

        public override void Write(
            Utf8JsonWriter writer,
            GenderOptions value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
