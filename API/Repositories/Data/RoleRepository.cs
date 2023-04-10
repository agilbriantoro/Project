using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<int, Roles>
    {
        public RoleRepository(MyContext context) : base(context)
        {
        }
    }
}
