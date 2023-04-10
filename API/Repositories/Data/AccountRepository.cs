using API.Contexts;
using API.Handlers;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepository : GeneralRepository<string, Account>
    {
        private readonly MyContext context;

        public AccountRepository(MyContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> Register(RegisterVM registerVM)
        {
            int result = 0;
            Departments departments = new Departments
            {
                Name = registerVM.DepartmentName
            };

            // Bikin kondisi untuk mengecek apakah data departement sudah ada
            if (await context.Departments.AnyAsync(u => u.Name == departments.Name))
            {
                departments.Id = context.Departments.FirstOrDefault(u => u.Name == departments.Name).Id;
            }
            else
            {
                await context.Departments.AddAsync(departments);
                result = await context.SaveChangesAsync();
            }

            Positions positions = new Positions
            {
                Name = registerVM.PositionName
            };

            // Bikin kondisi untuk mengecek apakah data position sudah ada
            if (await context.Positions.AnyAsync(u => u.Name == positions.Name))
            {
                positions.Id = context.Positions.FirstOrDefault(u => u.Name == positions.Name).Id;
            }
            else
            {
                await context.Positions.AddAsync(positions);
                result = await context.SaveChangesAsync();
            }

            Addresses addresses = new Addresses
            {
                Address = registerVM.AddressName
            };

            // Bikin kondisi untuk mengecek apakah data address sudah ada
            if (await context.Addresses.AnyAsync(u => u.Address == addresses.Address))
            {
                addresses.Id = context.Addresses.FirstOrDefault(u => u.Address == addresses.Address).Id;
            }
            else
            {
                await context.Addresses.AddAsync(addresses);
                result = await context.SaveChangesAsync();
            }

            Employee employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                HiringDate = registerVM.HiringDate,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
            };
            await context.Employees.AddAsync(employee);
            result = await context.SaveChangesAsync();

            Account account = new Account
            {
                EmployeeNIK = registerVM.NIK,
                Password = Hashing.HashPassword(registerVM.Password),
            };
            await context.Accounts.AddAsync(account);
            result = await context.SaveChangesAsync();

            AccountRole accountRole = new AccountRole
            {
                AccountNIK = registerVM.NIK,
                RoleId = 2
            };

            await context.AccountRoles.AddAsync(accountRole);
            result = await context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var getAccount = await context.Employees
                .Include(e => e.Account)
                .Select(e => new LoginVM
                {
                    Email = e.Email,
                    Password = e.Account.Password
                }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

            if (getAccount is null)
            {
                return false;
            }

            return Hashing.ValidatePassword(loginVM.Password, getAccount.Password);
        }

        public UserdataVM GetUserdata(string email)
        {
            var userdata = (from e in context.Employees
                            join a in context.Accounts
                            on e.NIK equals a.EmployeeNIK
                            join ar in context.AccountRoles
                            on a.EmployeeNIK equals ar.AccountNIK
                            join r in context.Roles
                            on ar.RoleId equals r.Id
                            where e.Email == email
                            select new UserdataVM
                            {
                                Email = e.Email,
                                FullName = String.Concat(e.FirstName, " ", e.LastName)
                            }).FirstOrDefault();

            return userdata;
        }
        public List<string> GetRolesByNIK(string email)
        {
            var getNIK = context.Employees.FirstOrDefault(e => e.Email == email);
            return context.AccountRoles.Where(ar => ar.AccountNIK == getNIK.NIK).Join(
                context.Roles,
                ar => ar.RoleId,
                r => r.Id,
                (ar, r) => r.Name).ToList();

        }
    }
}
