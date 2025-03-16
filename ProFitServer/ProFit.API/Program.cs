using Microsoft.EntityFrameworkCore;
using ProFit.Service.Services;
using ProFit.Core.IServices;
using ProFit.Data;
using System.Configuration;
using ProFit.Core.IRepositories;
using ProFit.Data.Reposories;
using ProFit.Data.Repositories;
using ProFit.API.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProFit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<DataContext>(
                options => options.UseMySQL("Server=bc6mrmq0t2din2zxkdjl-mysql.services.clever-cloud.com;Database=bct2din2zxkdjl;Uid=ujjthrzf1g;Pwd=qNRbTyhfghfKRjVQ;Port=3306;"));
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<ICVService, CVService>();
            builder.Services.AddScoped<IJobService, JobService>();

            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();
            builder.Services.AddScoped<ICVRepository, CVRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = builder.Configuration["JWT:Issuer"],
                     ValidAudience = builder.Configuration["JWT:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                 };
             });

            var app = builder.Build();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
