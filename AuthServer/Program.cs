using AuthServer.Bll.Abstractions;
using AuthServer.Bll.Services;
using AuthServer.DAL;
using AuthServer.DAL.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AuthServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration["ConnectionString:Defaultconnection"];
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddScoped<IAccountService,AccountService>();
            builder.Services.AddScoped<IUserRepository,SqlUserRepository>();
            builder.Services.AddDbContext<AuthContext>(context =>
            {
                context.UseNpgsql(connectionString);
            });

            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.Run();
        }
    }
}