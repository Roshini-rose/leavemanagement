using leavemanagement.Contracts;
using leavemanagement.Data;

namespace leavemanagement.Repositories
{
    public class LeaveRequestRepository:GenericRepository<leaverequest>,ILeaveRequestRepository
    {
        public LeaveRequestRepository(ApplicationDbContext context) : base(context) 
        {
        }
    }
}
