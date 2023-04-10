using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class CountryRepository : GeneralRepository<int, Countries>
    {
        public CountryRepository(MyContext context) : base(context)
        {
        }
    }
}
