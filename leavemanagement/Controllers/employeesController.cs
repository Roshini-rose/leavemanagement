using AutoMapper;
using leavemanagement.Constants;
using leavemanagement.Contracts;
using leavemanagement.Data;
using leavemanagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace leavemanagement.Controllers
{
    public class employeesController : Controller
    {
        private readonly UserManager<employee> userManager;
        private readonly IMapper mapper;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public employeesController(UserManager<employee> userManager, IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            this.userManager=userManager;
            this.mapper=mapper; 
            this.leaveAllocationRepository=leaveAllocationRepository;
            this.leaveTypeRepository=leaveTypeRepository;
        }

        // GET: employeesController
        public async Task<IActionResult> Index()
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var model = mapper.Map<List<employeelistvm>>(employees);
            return View(model);
        }

        // GET: employeesController/ViewAllocations/5
        public async Task<ActionResult> ViewAllocations(string id)
        {
            var model=await leaveAllocationRepository.getemployeeallocations(id);
            return View(model);
        }

        // GET: employeesController/EditAllocation/5
        public async Task<ActionResult> EditAllocation(int id)
        {
            var model= await leaveAllocationRepository.getemployeeallocation(id);      
            if(model==null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: employeesController/EditAllocation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAllocation(int id, leaveallocationeditvm model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(await leaveAllocationRepository.updateemployeeallocation(model))
                    {
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.employeeid });
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error occurred. Try Later");
            }
            model.employee=mapper.Map<employeelistvm>(await userManager.FindByIdAsync(model.employeeid));   
            model.leavetype= mapper.Map<leavetypevm>(await leaveTypeRepository.GetAsync(model.leavetypeid));    
            return View(model);
        }
    }
}
