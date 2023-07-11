using AutoMapper;
using leavemanagement.Contracts;
using leavemanagement.Data;
using leavemanagement.Migrations;
using leavemanagement.Models;
using leavemanagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace leavemanagement.Repositories
{
    public class LeaveRequestRepository:GenericRepository<leaverequest>,ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly UserManager<employee> userManager;
        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            UserManager<employee> userManager) : base(context) 
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.userManager = userManager;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.cancelled = true;
            await UpdateAsync(leaveRequest);

        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.approved = approved;

            if (approved)
            {
                var allocation = await leaveAllocationRepository.getemployeeallocation(leaveRequest.requestingemployeeid, leaveRequest.leavetypeid);
                int daysRequested = (int)(leaveRequest.enddate - leaveRequest.startdate).TotalDays;
                allocation.noofdays -= daysRequested;

                await leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

        }

        public async Task<bool> createleaverequest(leaverequestcreatevm model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);

            var leaveAllocation = await leaveAllocationRepository.getemployeeallocation(user.Id, model.leavetypeid);

            if (leaveAllocation == null)
            {
                return false;
            }

            int daysRequested = (int)(model.enddate.Value - model.startdate.Value).TotalDays;

            if (daysRequested > leaveAllocation.noofdays)
            {
                return false;
            }

            var leaveRequest = mapper.Map<leaverequest>(model);
            leaveRequest.daterequested = DateTime.UtcNow;
            leaveRequest.requestingemployeeid = user.Id;

            await AddAsync(leaveRequest);

            return true;
        }

        public async Task<adminleaverequestviewvm> GetAdminLeaveRequestList()
        {
            var leaveRequests = await context.leaverequests.Include(q => q.leavetype).ToListAsync();
            var model = new adminleaverequestviewvm
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.approved == true),
                PendingRequests = leaveRequests.Count(q => q.approved == null),
                RejectedRequests = leaveRequests.Count(q => q.approved == false),
                LeaveRequests = mapper.Map<List<leaverequestvm>>(leaveRequests),
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.employee = mapper.Map<employeelistvm>(await userManager.FindByIdAsync(leaveRequest.requestingemployeeid));
            }

            return model;
        }

        public async Task<List<leaverequest>> GetAllAsync(string employeeid)
        {
            return await context.leaverequests.Where(q=>q.requestingemployeeid==employeeid).ToListAsync();
        }

        public async Task<leaverequestvm?> GetLeaveRequestAsync(int? id)
        {
              var leaveRequest = await context.leaverequests
                .Include(q => q.leavetype)
                .FirstOrDefaultAsync(q => q.id == id);

            if (leaveRequest == null)
            {
                return null;
            }

            var model = mapper.Map<leaverequestvm>(leaveRequest);
            model.employee = mapper.Map<employeelistvm>(await userManager.FindByIdAsync(leaveRequest?.requestingemployeeid));
            return model;
        }

        public async Task<employeeleaverequestviewvm> getmyleavedetails()
        {
            var user= await userManager.GetUserAsync (httpContextAccessor?.HttpContext?.User);
            var allocations = (await leaveAllocationRepository.getemployeeallocations(user.Id)).leaveallocations;
            var requests= mapper.Map<List<leaverequestvm>>(await GetAllAsync(user.Id));

            var model=new employeeleaverequestviewvm(allocations, requests);

            return model;
        }

        Task<bool> ILeaveRequestRepository.createleaverequest(leaverequestcreatevm request)
        {
            throw new NotImplementedException();
        }
    }
}
