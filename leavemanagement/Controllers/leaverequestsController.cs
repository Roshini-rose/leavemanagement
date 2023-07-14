using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using leavemanagement.Data;
using leavemanagement.Models;
using leavemanagement.Contracts;
using Microsoft.AspNetCore.Authorization;
using leavemanagement.Constants;

namespace leavemanagement.Controllers
{
    [Authorize]
    public class leaverequestsController : Controller
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly ILogger<leaverequestsController> logger;

        public leaverequestsController(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, 
            ILogger<leaverequestsController> logger)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.logger = logger;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        [Authorize(Roles=Roles.Administrator)]

        // GET: leaverequests
        public async Task<IActionResult> Index()
        {
            var model =await leaveRequestRepository.GetAdminLeaveRequestList();
            return View(model);
        }

        public async Task<ActionResult> MyLeave()
        {
            var model= await leaveRequestRepository.getmyleavedetails();
            return View(model);
        }

        // GET: leaverequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await leaveRequestRepository.GetLeaveRequestAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await leaveRequestRepository.ChangeApprovalStatus(id, approved);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Approving Leave Request");
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await leaveRequestRepository.CancelLeaveRequest(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Cancelling Leave Request");
                throw;
            }
            return RedirectToAction(nameof(MyLeave));
        }


        // GET: leaverequests/Create
        public async Task<IActionResult> Create()
        {
            var model = new leaverequestcreatevm
            {
                leavetypes = new SelectList(await leaveTypeRepository.GetAllAsync(), "id", "name")
            };
            return View(model);
        }

        // POST: leaverequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(leaverequestcreatevm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isValidRequest=await leaveRequestRepository.createleaverequest(model);
                    if(isValidRequest)
                    {
                        return RedirectToAction(nameof(MyLeave));
                    }
                    ModelState.AddModelError(string.Empty, "Exceeded your allocation");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Creating Leave Request");
                ModelState.AddModelError(string.Empty, "Error Occurred. Try Later"+ex.Message);
            }

            model.leavetypes= new SelectList(await leaveTypeRepository.GetAllAsync(), "id", "name", model.leavetypeid);
            return View(model);
        }
    }
}
