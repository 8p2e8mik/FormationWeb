using Formation.WebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDbContext<MyDbContext>(
        opt => opt.UseSqlServer(
            connectionString: builder.Configuration.GetConnectionString("MyConnectionString"),
            contextOptBuilder => contextOptBuilder.MigrationsAssembly("Formation.WebAPI")));

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