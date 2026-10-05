
using LibrarySystem.App_Context;
using LibrarySystem.Mapping;
using LibrarySystem.Repo.Implmentation;
using LibrarySystem.Repo.Interface;
using LibrarySystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUnitWork, UnitWork>();
            builder.Services.AddScoped(typeof(IGenariceRepo<>), typeof(GenaricRepo<>));
            builder.Services.AddScoped<IBook, BookRepo>();
            builder.Services.AddAutoMapper(a => a.AddProfile<MppingProfile>());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
