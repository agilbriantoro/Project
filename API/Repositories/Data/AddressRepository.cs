using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class AddressRepository : GeneralRepository<int, Address>
    {
        public AddressRepository(MyContext context) : base(context)
        {
        }
    }
}
