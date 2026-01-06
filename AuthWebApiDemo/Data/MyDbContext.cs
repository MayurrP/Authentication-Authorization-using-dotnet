using AuthWebApiDemo.Entites;
using Microsoft.EntityFrameworkCore;

namespace AuthWebApiDemo.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
}