using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ForumASPMVC.Data;
using ForumASPMVC.Models;
using ForumASPMVC.Models.ViewModels;

namespace ForumASPMVC.Controllers
{
    public class ThreadOnesController : Controller
    {
        private readonly ForumDbContext _context;

        public ThreadOnesController(ForumDbContext context)
        {
            _context = context;
        }

        // GET: ThreadOnes
        public async Task<IActionResult> Index()
        {
            var forumDbContext = _context.ThreadOnes.Include(t => t.Topic);
            return View(await forumDbContext.ToListAsync());
        }

        // GET: ThreadOnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ThreadOnes == null)
            {
                return NotFound();
            }

            var threadOne = await _context.ThreadOnes
                .Include(t => t.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threadOne == null)
            {
                return NotFound();
            }

            return View(threadOne);
        }

        // GET: ThreadOnes/Create
        public IActionResult Create()
        {
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id");
            return View();
        }

        // POST: ThreadOnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateThreadOneViewModel createThreadOneViewModel)
        {
            if (ModelState.IsValid)
            {

                ThreadOne threadOne = new ThreadOne()
                {
                    Title = createThreadOneViewModel.Title,
                    Text = createThreadOneViewModel.Text,
                    TopicId = createThreadOneViewModel.TopicId,
                    Created = DateTime.Now,
                };
                _context.Add(threadOne);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Topics",  new { id = threadOne.TopicId});
            }
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", createThreadOneViewModel.TopicId);
            return View(createThreadOneViewModel);
        }

        // GET: ThreadOnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThreadOnes == null)
            {
                return NotFound();
            }

            var threadOne = await _context.ThreadOnes.FindAsync(id);
            if (threadOne == null)
            {
                return NotFound();
            }
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", threadOne.TopicId);
            return View(threadOne);
        }

        // POST: ThreadOnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,Created,TopicId")] ThreadOne threadOne)
        {
            if (id != threadOne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threadOne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreadOneExists(threadOne.Id))
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
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", threadOne.TopicId);
            return View(threadOne);
        }

        // GET: ThreadOnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThreadOnes == null)
            {
                return NotFound();
            }

            var threadOne = await _context.ThreadOnes
                .Include(t => t.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threadOne == null)
            {
                return NotFound();
            }

            return View(threadOne);
        }

        // POST: ThreadOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ThreadOnes == null)
            {
                return Problem("Entity set 'ForumDbContext.ThreadOnes'  is null.");
            }
            var threadOne = await _context.ThreadOnes.FindAsync(id);
            if (threadOne != null)
            {
                _context.ThreadOnes.Remove(threadOne);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreadOneExists(int id)
        {
          return (_context.ThreadOnes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
