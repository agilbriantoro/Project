using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Data
{
    public class LeaveTypeRepository : GeneralRepository<LeaveType, int>
    {
        public LeaveTypeRepository(string request = "LeaveType/") : base(request)
        {
        }
    }
}
