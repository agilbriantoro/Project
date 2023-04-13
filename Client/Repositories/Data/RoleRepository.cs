using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, int>
    {
        public RoleRepository(string request = "Role/") : base(request)
        {
        }
    }
}
