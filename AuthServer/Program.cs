using AuthServer.Bll.Abstractions;
using AuthServer.Bll.Models;
using AuthServer.Bll.Services;
using AuthServer.DAL;
using AuthServer.DAL.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var connectionString = builder.Configuration["ConnectionString:Defaultconnection"];
            //Подргузка серетных значений
            builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("JwtSettings"));
            var secretKey = builder.Configuration.GetSection("JwtSettings:SecretKey").Value;
            var issuer = builder.Configuration.GetSection("JwtSettings:Issuer").Value;
            var audience = builder.Configuration.GetSection("JwtSettings:Audience").Value; 
            var signKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //Установка аутентификации с помощью токена по единой схеме
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //Установка параметров валидации токена. Указываем, что нужно проверять
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Проверка издателя
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    //Проверка потребителя
                    ValidateAudience = true,
                    ValidAudience = audience,
                    //Проверка жизни токена
                    ValidateLifetime = true,
                    //Проверка секретного ключа
                    IssuerSigningKey = signKey,
                    ValidateIssuerSigningKey = true
                };
            });

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddSingleton<TokenOptions>();
            builder.Services.AddScoped<IAccountService,AccountService>();
            builder.Services.AddScoped<IUserRepository,SqlUserRepository>();
            builder.Services.AddDbContext<AuthContext>(context =>
            {
                context.UseNpgsql(connectionString);
            });

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.Run();
        }
    }
}