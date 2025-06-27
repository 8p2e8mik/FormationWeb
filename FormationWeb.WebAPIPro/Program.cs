using FormationWeb.Application.Contracts;
using FormationWeb.Application.Services;
using FormationWeb.Domain.Contracts;
using FormationWeb.Domain.Models;
using FormationWeb.Repository.CommandQueries;
using FormationWeb.Repository.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDbContext<MyDbContext>(
        opt => opt.UseSqlServer(
            builder.Configuration.GetConnectionString("MyConnectionString"),
            contextOptBuilder => contextOptBuilder.MigrationsAssembly("FormationWeb.Repository")));

    builder.Services.AddScoped<IUserContract<User>, UserRepository>();
    builder.Services.AddScoped<IUserService<User>, UserService>();

    builder.Services.AddScoped<IUserDetailsContract<UserDetails>, UserDetailsRepository>();
    builder.Services.AddScoped<IUserDetailsService<UserDetails>, UserDetailsService>();

    
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
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