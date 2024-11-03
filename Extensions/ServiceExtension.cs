using System.Data;
using ANEFreeInIty_Server_API.Repositories;
using ANEFreeInIty_Server_API.Repositories.Contracts;
using ANEFreeInIty_Server_API.Services;
using ANEFreeInIty_Server_API.Services.Contracts;
using Microsoft.AspNetCore.Http.Features;
using Npgsql;

namespace ANEFreeInIty_Server_API.Extensions;
public static class ServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

    public static void ConfigureUploadLimit(this IServiceCollection services) =>
        services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 1024 * 1024 * 100;
        });

    public static void ConfigureDBConnection(this IServiceCollection services, IConfiguration config) =>
        services.AddScoped<IDbConnection>(db => new NpgsqlConnection(config.GetConnectionString("DefaultConnection")));

    public static void InjectRepository(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void InjectService(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
}