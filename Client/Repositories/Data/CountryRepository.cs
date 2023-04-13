using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class CountryRepository : GeneralRepository<Country, int>
    {
        public CountryRepository(string request = "Country/") : base(request)
        {
        }
    }
}
