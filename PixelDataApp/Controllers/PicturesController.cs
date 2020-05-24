using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.EntityFrameworkCore;
using PixelDataApp.Data;
using PixelDataApp.Models;

namespace PixelDataApp.Controllers
{
    public class PicturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PicturesController> _logger;

        public PicturesController(ApplicationDbContext context, ILogger<PicturesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Pictures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pictures.Include(p => p.Answer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures
                .Include(p => p.Answer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // GET: Pictures/Create
        public IActionResult Create()
        {
            ViewData["AnswerId"] = new SelectList(_context.Labels, "Id", "Name");
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Filepath,PublishTime,Info,AnswerId")] Picture picture, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                picture.PublishTime = DateTime.Now;
                
                _context.Add(picture);
                _context.SaveChanges();

                if (file != null && file.Length > 0)
                {
                    var label = _context.Labels.Find(picture.AnswerId);
                    picture.Filepath = Path.Combine("PixelData", "files", label.LabelGroup.Name, label.StringID, picture.Id.ToString());
                }

                using(var stream = new FileStream(picture.Filepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                _context.Update(picture);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            ViewData["AnswerId"] = new SelectList(_context.Labels, "Id", "Name", picture.AnswerId);
            return View(picture);
        }

        // GET: Pictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures.FindAsync(id);
            if (picture == null)
            {
                return NotFound();
            }
            ViewData["AnswerId"] = new SelectList(_context.Labels, "Id", "Name", picture.AnswerId);
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Filepath,PublishTime,Info,AnswerId")] Picture picture)
        {
            if (id != picture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(picture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureExists(picture.Id))
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
            ViewData["AnswerId"] = new SelectList(_context.Labels, "Id", "Name", picture.AnswerId);
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures
                .Include(p => p.Answer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureExists(int id)
        {
            return _context.Pictures.Any(e => e.Id == id);
        }
    }
}
