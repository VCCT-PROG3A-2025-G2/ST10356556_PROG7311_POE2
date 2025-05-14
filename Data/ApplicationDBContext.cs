namespace Agri_Energy_Connect.Data;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) //Database method
        : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Product> Products { get; set; }
}
