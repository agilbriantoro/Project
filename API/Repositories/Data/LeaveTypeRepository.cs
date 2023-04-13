using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class LeaveTypeRepository : GeneralRepository<int, LeaveType>
    {
        public LeaveTypeRepository(MyContext context) : base(context)
        {
        }
    }
}
