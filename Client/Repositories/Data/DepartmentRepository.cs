using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<Departments, int>
    {
        public DepartmentRepository(string request = "Department/") : base(request)
        {
        }
    }
}
