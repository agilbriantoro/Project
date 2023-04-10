using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class AddressRepository : GeneralRepository<int, Addresses>
    {
        public AddressRepository(MyContext context) : base(context)
        {
        }
    }
}
