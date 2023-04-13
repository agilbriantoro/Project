using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class CountryRepository : GeneralRepository<Countries, int>
    {
        public CountryRepository(string request = "Country/") : base(request)
        {
        }
    }
}
