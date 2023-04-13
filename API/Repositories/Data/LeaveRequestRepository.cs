using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class LeaveRequestRepository : GeneralRepository<int, LeaveRequest>
    {
        public LeaveRequestRepository(MyContext context) : base(context)
        {
        }
    }
}
