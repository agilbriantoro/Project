using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class LeaveRequestRepository : GeneralRepository<int, LeaveRequests>
    {
        public LeaveRequestRepository(MyContext context) : base(context)
        {
        }
    }
}
