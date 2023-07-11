using leavemanagement.Data;
using leavemanagement.Models;

namespace leavemanagement.Contracts
{
    public interface ILeaveAllocationRepository: IGenericRepository<leaveallocation>
    {
        Task leaveallocation(int leavetypeid);
        Task<bool>allocationexists(string employeeid,int leavetypeid, int period);
        Task<employeeallocationvm> getemployeeallocations(string employeeid);
        Task<leaveallocation?> getemployeeallocation(string employeeid, int leavetypeid);

        Task<leaveallocationeditvm> getemployeeallocation(int id);
        Task<bool> updateemployeeallocation(leaveallocationeditvm model);
    }
}
