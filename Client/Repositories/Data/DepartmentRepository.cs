using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<Department, int>
    {
        public DepartmentRepository(string request = "Department/") : base(request)
        {
        }
    }
}
