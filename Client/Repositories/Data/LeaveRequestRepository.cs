using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class LeaveRequestRepository : GeneralRepository<LeaveRequest, int>
    {
        public LeaveRequestRepository(string request = "LeaveRequest/") : base(request)
        {
        }
    }
}
