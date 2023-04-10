using API.Contexts;
using API.Handlers;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Net;

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
            Countries country = new Countries
            {
                Name = registerVM.CountryName
            };
            if (await context.Countries.AnyAsync(c => c.Name == country.Name))
            {
                country.Id = context.Countries.FirstOrDefault(c => c.Name == country.Name).Id;
            }
            else
            {
                await context.Countries.AddAsync(country);
                result = await context.SaveChangesAsync();
            }

            Cities city = new Cities
            {
                Name = registerVM.CityName,
                CountryId = country.Id
            };
            if (await context.Cities.AnyAsync(c => c.Name == city.Name))
            {
                city.Id = context.Cities.FirstOrDefault(c => c.Name == city.Name).Id;
            }
            else
            {
                await context.Cities.AddAsync(city);
                result = await context.SaveChangesAsync();
            }

            Addresses address = new Addresses
            {
                Address = registerVM.AddressName,
                PostalCode = registerVM.PostalCode,
                CityId = city.Id,
            };
            await context.Addresses.AddAsync(address);
            result = await context.SaveChangesAsync();

            Departments departments = new Departments
            {
                Name = registerVM.DepartmentName,
                Address_Id = address.Id
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

            Employee employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                PhoneNumber = registerVM.PhoneNumber,
                AddressId = address.Id,
                DepartmentId = departments.Id,
                PositionId = positions.Id
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
                AccountNIK = account.EmployeeNIK,
                RoleId = 2
            };
            await context.AccountRoles.AddAsync(accountRole);
            result = await context.SaveChangesAsync();

            return result;
        }
        public async Task<bool> Login(LoginVM loginVM)
        {
            var getAccount = await context.Employees
                .Include(s => s.Account)
                .Select(s => new LoginVM
                {
                    Email = s.Email,
                    Password = s.Account.Password
                }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

            if (getAccount is null)
            {
                return false;
            }

            return Hashing.ValidatePassword(loginVM.Password, getAccount.Password);
        }
        public async Task<UserdataVM> GetUserdata(string email)
        {
            var userdata = await (from u in context.Employees
                                  join a in context.Accounts
                                  on u.NIK equals a.EmployeeNIK
                                  join ar in context.AccountRoles
                                  on a.EmployeeNIK equals ar.AccountNIK
                                  join r in context.Roles
                                  on ar.RoleId equals r.Id
                                  where u.Email == email
                                  select new UserdataVM
                                  {
                                      Email = u.Email,
                                      FullName = string.Concat(u.FirstName, " ", u.LastName)
                                  }).FirstOrDefaultAsync();

            return userdata;
        }
        public async Task<IEnumerable<string>> GetRolesById(string email)
        {
            var getUserId = await context.Employees.FirstOrDefaultAsync(u => u.Email == email);
            return await context.AccountRoles.Where(ar => ar.AccountNIK == getUserId.NIK).Join(
                context.Roles,
                ar => ar.RoleId,
                r => r.Id,
                (ar, r) => r.Name).ToListAsync();
        }
    }
}
