using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using UserService.API;
using UserService.API.MiddleWares;
using UserService.Core;
using UserService.Core.Mappers;
using UserService.Domain.Enums;
using UserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers();

/*builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase,false)
        );
    });*/

/*builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        // Register your safe enum converter for the GenderOptions enum
        options.JsonSerializerOptions.Converters.Add(new SafeEnumConverter<GenderOptions>());
        // Keep other converters if needed, e.g. for string enums:
        // options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });*/
//builder.Services.AddControllers();
//builder.Services.AddControllers().AddJsonOptions(options=> options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

//builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new SafeEnumConverter ()));

var app = builder.Build();

//app.UseMiddleware<UserService.API.MiddleWares.JsonBodyExceptionMiddleware>();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.Run();
