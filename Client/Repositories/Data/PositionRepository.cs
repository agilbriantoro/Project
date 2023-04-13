using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class PositionRepository : GeneralRepository<Position, int>
    {
        public PositionRepository(string request = "Position/") : base(request)
        {
        }
    }
}
