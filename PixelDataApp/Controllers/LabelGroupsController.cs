using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PixelDataApp.Data;
using PixelDataApp.Models;

namespace PixelDataApp.Controllers
{
    public class LabelGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabelGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LabelGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabelGroups.ToListAsync());
        }

        // GET: LabelGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelGroup = await _context.LabelGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelGroup == null)
            {
                return NotFound();
            }

            return View(labelGroup);
        }

        // GET: LabelGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabelGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NameRu")] LabelGroup labelGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labelGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labelGroup);
        }

        // GET: LabelGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelGroup = await _context.LabelGroups.FindAsync(id);
            if (labelGroup == null)
            {
                return NotFound();
            }
            return View(labelGroup);
        }

        // POST: LabelGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NameRu")] LabelGroup labelGroup)
        {
            if (id != labelGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labelGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelGroupExists(labelGroup.Id))
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
            return View(labelGroup);
        }

        // GET: LabelGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelGroup = await _context.LabelGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelGroup == null)
            {
                return NotFound();
            }

            return View(labelGroup);
        }

        // POST: LabelGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labelGroup = await _context.LabelGroups.FindAsync(id);
            _context.LabelGroups.Remove(labelGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelGroupExists(int id)
        {
            return _context.LabelGroups.Any(e => e.Id == id);
        }
    }
}
