using leavemanagement.Data;
using leavemanagement.Migrations;
using leavemanagement.Models;

namespace leavemanagement.Contracts
{
    public interface ILeaveRequestRepository:IGenericRepository<leaverequest>
    {
        Task<bool> createleaverequest(leaverequestcreatevm model);
        Task<employeeleaverequestviewvm> getmyleavedetails();
        Task<List<leaverequestvm>> GetAllAsync(string employeeid);
        Task<adminleaverequestviewvm> GetAdminLeaveRequestList();
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task CancelLeaveRequest(int leaveRequestId);
        Task<leaverequestvm?> GetLeaveRequestAsync(int? id);

    }
}
