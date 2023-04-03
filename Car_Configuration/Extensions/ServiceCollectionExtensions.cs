using Car_Configuration.Data;
using Car_Configuration.Entities;
using Microsoft.EntityFrameworkCore;

namespace Car_Configuration.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAppDbContext(this IServiceCollection collection, ConfigurationManager configuration)
    {
        collection.AddDbContext<AppDbContext>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-7D68517\\SQLEXPRESS;Database=Car_Configurationdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        });
    }

    public static void AddIdentityManagers(this IServiceCollection collection)
    {
        collection.AddIdentity<User, UserRole>(options =>
        {
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
        }).AddRoles<UserRole>().AddEntityFrameworkStores<AppDbContext>();
    }
}
