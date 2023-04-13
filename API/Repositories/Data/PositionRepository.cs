using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class PositionRepository : GeneralRepository<int, Position>
    {
        public PositionRepository(MyContext context) : base(context)
        {
        }
    }
}
