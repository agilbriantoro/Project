using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class CityRepository : GeneralRepository<Cities, int>
    {
        public CityRepository(string request = "City/") : base(request)
        {
        }
    }
}
