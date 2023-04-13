using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class LeaveRequestRepository : GeneralRepository<LeaveRequests, int>
    {
        public LeaveRequestRepository(string request = "LeaveRequest/") : base(request)
        {
        }
    }
}
