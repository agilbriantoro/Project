using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {
        public EmployeeRepository(string request = "Employee/") : base(request)
        {
        }
    }
}
