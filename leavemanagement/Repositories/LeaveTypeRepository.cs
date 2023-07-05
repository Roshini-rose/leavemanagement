using leavemanagement.Contracts;
using leavemanagement.Data;

namespace leavemanagement.Repositories
{
    public class LeaveTypeRepository: GenericRepository<leavetype>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }    
    }
}
