#nullable disable

using DotNetWebApiSupport.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebApiSupport.Models
{
  public class AWLTDbContext : DbContext
  {
    public AWLTDbContext(DbContextOptions<AWLTDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

  }
}