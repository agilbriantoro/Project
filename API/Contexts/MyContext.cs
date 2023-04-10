using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    // Introduce the model to the database that eventually become an entity
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Addresses> Addresses { get; set; }
    public DbSet<Cities> Cities { get; set; }
    public DbSet<Countries> Countries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Departments> Departments { get; set; }
    public DbSet<LeaveRequests> LeaveRequests { get; set; }
    public DbSet<LeaveTypes> LeaveTypes { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Positions> Positions { get; set; }

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Roles>().HasData(
            new Roles
            {
                Id = 1,
                Name = "Admin"
            },
            new Roles
            {
                Id = 2,
                Name = "User"
            });

        // Membuat atribute menjadi unique
        modelBuilder.Entity<Employee>().HasIndex(e => new
        {
            e.Email,
            e.PhoneNumber
        }).IsUnique();

        // Relasi one Employee ke one Account 
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Account)
            .WithOne(a => a.Employee)
            .HasForeignKey<Account>(fk => fk.EmployeeNIK);

        // Relasi ke many employee ke one manager
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(e => e.Employees)
            .HasForeignKey(fk => fk.ManagerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}