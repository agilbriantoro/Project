using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {
        public EmployeeRepository(string request = "Employee/") : base(request)
        {
        }
    }
}
