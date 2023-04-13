using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Roles, int>
    {
        public RoleRepository(string request = "Role/") : base(request)
        {
        }
    }
}
