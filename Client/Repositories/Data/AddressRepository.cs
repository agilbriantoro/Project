using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class AddressRepository : GeneralRepository<Address, int>
    {
        public AddressRepository(string request = "Address/") : base(request)
        {
        }
    }
}
