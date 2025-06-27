using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FormationWeb.Repository.Persistence;

// public class MyDbContextDesignTime : IDesignTimeDbContextFactory<MyDbContext>
// {
//     public MyDbContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
//         optionsBuilder.UseSqlServer("Server=MarcAu-Windows;Database=FormationDbPro;Trusted_Connection=true;TrustServerCertificate=true");
//
//         return new MyDbContext(optionsBuilder.Options);
//     }
// }