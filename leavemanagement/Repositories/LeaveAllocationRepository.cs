using AutoMapper;
using leavemanagement.Constants;
using leavemanagement.Contracts;
using leavemanagement.Data;
using leavemanagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace leavemanagement.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<leaveallocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<employee> userManager,
            ILeaveTypeRepository leaveTypeRepository, IMapper mapper) : base(context)
        {
            this.userManager=userManager;
            this.leaveTypeRepository=leaveTypeRepository;
            this.mapper=mapper;

        }

        public async Task<bool> allocationexists(string employeeid, int leavetypeid, int period)
        {
            return await context.leaveallocations.AnyAsync(q=> q.employeeid == employeeid && q.leavetypeid==leavetypeid && q.period==period);
        }

        public async Task<employeeallocationvm> getemployeeallocations(string employeeid)
        {
            var allocations = await context.leaveallocations
                .Include(q => q.leavetype)
                .Where(q => q.employeeid == employeeid).ToListAsync();
            var employee = await userManager.FindByIdAsync(employeeid);

            var employeeallocationmodel= mapper.Map<employeeallocationvm>(employee);
            employeeallocationmodel.leaveallocations=mapper.Map<List<leaveallocationvm>>(allocations);

            return employeeallocationmodel;
        }

        public async Task<leaveallocationeditvm> getemployeeallocation(int id)
        {
            var allocation = await context.leaveallocations
                .Include(q => q.leavetype)
               .FirstOrDefaultAsync(q => q.id == id);
            if(allocation==null)
            {
                return null;
            }
            var employee = await userManager.FindByIdAsync(allocation.employeeid);

            var model = mapper.Map<leaveallocationeditvm>(allocation);
            model.employee = mapper.Map<employeelistvm>(await userManager.FindByIdAsync(allocation.employeeid));

            return model;
        }

        public async Task leaveallocation(int leavetypeid)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leavetype= await leaveTypeRepository.GetAsync(leavetypeid);
            var allocations = new List<leaveallocation>();

            foreach(var employee in employees)
            {
                if (await allocationexists(employee.Id, leavetypeid, period))
                    continue;
                allocations.Add (new leaveallocation
                {
                    employeeid = employee.Id,
                    leavetypeid = leavetypeid,
                    period = period,
                    noofdays = leavetype.defaultdays
                });
            }
            await AddRangeAsync(allocations);   
        }

        public async Task<bool> updateemployeeallocation(leaveallocationeditvm model)
        {
            var leaveallocation = await GetAsync(model.id);
            if (leaveallocation == null)
            {
                return false;
            }
            leaveallocation.period = model.period;
            leaveallocation.noofdays = model.noofdays;
            await UpdateAsync(leaveallocation);

            return true; 
           
        }

        public async Task<leaveallocation?> getemployeeallocation(string employeeid, int leavetypeid)
        {
            return await context.leaveallocations.FirstOrDefaultAsync(q => q.employeeid == employeeid && q.leavetypeid == leavetypeid);
        }
    
    }
}
