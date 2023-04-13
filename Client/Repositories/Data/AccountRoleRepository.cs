using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int>
    {
        public AccountRoleRepository(string request = "AccountRole/") : base(request)
        {
        }
    }
}
