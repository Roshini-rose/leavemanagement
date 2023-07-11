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
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public leaverequestsController(ApplicationDbContext context, ILeaveRequestRepository leaveRequestRepository)
        {
            _context = context;
            this.leaveRequestRepository = leaveRequestRepository;
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

                throw;
            }
            return RedirectToAction(nameof(MyLeave));
        }


        // GET: leaverequests/Create
        public IActionResult Create()
        {
            var model = new leaverequestcreatevm
            {
                leavetypes = new SelectList(_context.leavetypes, "id", "name")
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
                ModelState.AddModelError(string.Empty, "Error Occurred. Try Later");
            }

            model.leavetypes= new SelectList(_context.leavetypes, "id", "name", model.leavetypeid);
            return View(model);
        }

        // GET: leaverequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.leaverequests == null)
            {
                return NotFound();
            }

            var leaverequest = await _context.leaverequests.FindAsync(id);
            if (leaverequest == null)
            {
                return NotFound();
            }
            ViewData["leavetypeid"] = new SelectList(_context.leavetypes, "id", "id", leaverequest.leavetypeid);
            return View(leaverequest);
        }

        // POST: leaverequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("startdate,enddate,leavetypeid,daterequested,requestcomments,approved,cancelled,requestingemployeeid,id,datecreated,datemodified")] leaverequest leaverequest)
        {
            if (id != leaverequest.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaverequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!leaverequestExists(leaverequest.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["leavetypeid"] = new SelectList(_context.leavetypes, "id", "id", leaverequest.leavetypeid);
            return View(leaverequest);
        }

        // GET: leaverequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.leaverequests == null)
            {
                return NotFound();
            }

            var leaverequest = await _context.leaverequests
                .Include(l => l.leavetype)
                .FirstOrDefaultAsync(m => m.id == id);
            if (leaverequest == null)
            {
                return NotFound();
            }

            return View(leaverequest);
        }

        // POST: leaverequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.leaverequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.leaverequests'  is null.");
            }
            var leaverequest = await _context.leaverequests.FindAsync(id);
            if (leaverequest != null)
            {
                _context.leaverequests.Remove(leaverequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool leaverequestExists(int id)
        {
          return (_context.leaverequests?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
