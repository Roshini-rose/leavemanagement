﻿using leavemanagement.Data;
using leavemanagement.Migrations;
using leavemanagement.Models;

namespace leavemanagement.Contracts
{
    public interface ILeaveRequestRepository:IGenericRepository<leaverequest>
    {
        Task<bool> createleaverequest(leaverequestcreatevm request);
        Task<employeeleaverequestviewvm> getmyleavedetails();
        Task<List<leaverequest>> GetAllAsync(string employeeid);
        Task<adminleaverequestviewvm> GetAdminLeaveRequestList();
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task CancelLeaveRequest(int leaveRequestId);
        Task<leaverequestvm?> GetLeaveRequestAsync(int? id);

    }
}
