using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class PositionRepository : GeneralRepository<Positions, int>
    {
        public PositionRepository(string request = "Position/") : base(request)
        {
        }
    }
}
