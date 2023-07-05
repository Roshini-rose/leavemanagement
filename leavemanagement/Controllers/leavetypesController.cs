using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using leavemanagement.Data;
using AutoMapper;
using leavemanagement.Models;
using leavemanagement.Contracts;

namespace leavemanagement.Controllers
{
    public class leavetypesController : Controller
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public leavetypesController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }

        // GET: leavetypes
        public async Task<IActionResult> Index()
        {
            var leavetypes = mapper.Map<List<leavetypevm>>(await leaveTypeRepository.GetAllAsync());   
            return View(leavetypes);
        }

        // GET: leavetypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leavetype = await leaveTypeRepository.GetAsync(id);
            if (leavetype == null)
            {
                return NotFound();
            }

            var leavetypevm=mapper.Map<leavetypevm>(leavetype);
            return View(leavetypevm);
        }

        // GET: leavetypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: leavetypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(leavetypevm leavetypevm)
        {
            if (ModelState.IsValid)
            {
                var leavetype = mapper.Map<leavetype>(leavetypevm);   
                await leaveTypeRepository.AddAsync(leavetype);
                return RedirectToAction(nameof(Index));
            }
            return View(leavetypevm);
        }

        // GET: leavetypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leavetype = await leaveTypeRepository.GetAsync(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            var leavetypevm = mapper.Map<leavetypevm>(leavetype);
            return View(leavetypevm);
        }

        // POST: leavetypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, leavetypevm leavetypevm)
        {
            if (id != leavetypevm.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leavetype = mapper.Map<leavetype>(leavetypevm);
                   await leaveTypeRepository.UpdateAsync(leavetype);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await leaveTypeRepository.Exists(leavetypevm.id))
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
            return View(leavetypevm);
        }

        // GET: leavetypes/Delete/5
      

        // POST: leavetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
