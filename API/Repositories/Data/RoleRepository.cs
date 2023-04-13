using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<int, Role>
    {
        public RoleRepository(MyContext context) : base(context)
        {
        }
    }
}
