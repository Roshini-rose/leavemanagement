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

namespace leavemanagement.Controllers
{
    public class leavetypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public leavetypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: leavetypes
        public async Task<IActionResult> Index()
        {
            var leavetypes = mapper.Map<List<leavetypevm>>(await _context.leavetypes.ToListAsync());   
            return View(leavetypes);
              //return _context.leavetypes != null ? 
                 //         View(await _context.leavetypes.ToListAsync()) :
                   //       Problem("Entity set 'ApplicationDbContext.leavetypes'  is null.");
        }

        // GET: leavetypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.leavetypes == null)
            {
                return NotFound();
            }

            var leavetype = await _context.leavetypes.FindAsync(id);
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
                _context.Add(leavetype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leavetypevm);
        }

        // GET: leavetypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.leavetypes == null)
            {
                return NotFound();
            }

            var leavetype = await _context.leavetypes.FindAsync(id);
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
                    _context.Update(leavetype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!leavetypeExists(leavetypevm.id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.leavetypes == null)
            {
                return NotFound();
            }

            var leavetype = await _context.leavetypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (leavetype == null)
            {
                return NotFound();
            }

            return View(leavetype);
        }

        // POST: leavetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.leavetypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.leavetypes'  is null.");
            }
            var leavetype = await _context.leavetypes.FindAsync(id);
            if (leavetype != null)
            {
                _context.leavetypes.Remove(leavetype);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool leavetypeExists(int id)
        {
          return (_context.leavetypes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
