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
<<<<<<< Updated upstream
    public DbSet<Address> Addresses { get; set; }
=======
    public DbSet<Addresses> Addresses { get; set; }
>>>>>>> Stashed changes
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<Role> Roles { get; set; }
<<<<<<< Updated upstream
    public DbSet<Position> Position { get; set; }
=======
    public DbSet<Position> Positions { get; set; }
>>>>>>> Stashed changes

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin"
            },
            new Role
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