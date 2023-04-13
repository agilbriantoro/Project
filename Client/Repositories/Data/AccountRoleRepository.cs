using Client.Models;
using Client.Repositories;

namespace Client.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int>
    {
        public AccountRoleRepository(string request = "AccountRole/") : base(request)
        {
        }
    }
}
