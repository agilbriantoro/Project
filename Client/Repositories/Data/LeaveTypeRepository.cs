using Client.Models;
using Client.Repositories;

namespace API.Repositories.Data
{
    public class LeaveTypeRepository : GeneralRepository<LeaveTypes, int>
    {
        public LeaveTypeRepository(string request = "LeaveType/") : base(request)
        {
        }
    }
}
