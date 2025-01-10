
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DataAccessLayer.Context;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
  {
        Database.CloseConnection();
  }

  public DbSet<Product> Products { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);


  }
}
