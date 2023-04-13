using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class AddressRepository : GeneralRepository<Addresses, int>
    {
        public AddressRepository(string request = "Addresses/") : base(request)
        {
        }
    }
}
