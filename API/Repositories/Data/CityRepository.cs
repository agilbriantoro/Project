using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class CityRepository : GeneralRepository<int, City>
    {
        public CityRepository(MyContext context) : base(context)
        {
        }
    }
}
