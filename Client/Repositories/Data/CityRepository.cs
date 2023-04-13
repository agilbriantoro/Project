using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class CityRepository : GeneralRepository<City, int>
    {
        public CityRepository(string request = "City/") : base(request)
        {
        }
    }
}
