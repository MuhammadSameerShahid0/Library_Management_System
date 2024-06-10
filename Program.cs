using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Library_Management_System.Interfaces;
using Library_Management_System.Repository;
using System.Text.Json.Serialization;
using Library_Management_System.Repositories;
using Library_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Library_Management_System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddTransient<Seed>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IBooksRepository, BooksRepository>();
        builder.Services.AddSingleton<ILoansRepository, LoanRepository>();
        builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
        builder.Services.AddSingleton<IBookAuthorRepository, BookAuthorRepository>();
       
        var app = builder.Build();

        if (args.Length == 1 && args[0].ToLower() == "seeddata")
            SeedData(app);

        void SeedData(IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopedFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<Seed>();
                service.SeedDataContext();
            }
        }
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