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
    public class TopicsController : Controller
    {
        private readonly ForumDbContext _context;

        public TopicsController(ForumDbContext context)
        {
            _context = context;
        }

        // GET: Topics
        public async Task<IActionResult> Index()
        {
            List<Topic> topics = _context.Topics != null ? await _context.Topics.ToListAsync() : null;



            //Problem("Entity set 'ForumDbContext.Topics'  is null.");


            List<ListTopicViewModel> topicList =new List<ListTopicViewModel>();


            foreach (var item in topics)
            {
                var viewModelTopic = new ListTopicViewModel() { Id = item.Id, Title = item.Title, Description = item.Description, Created= item.Created };

                topicList.Add(viewModelTopic);
            }

            return View(topicList);
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .Where(m => m.Id == id).Include(t=>t.Threads).ThenInclude(c=>c.Comments).ThenInclude(r=>r.Replies).FirstOrDefaultAsync();
            if (topic == null)
            {
                return NotFound();
            }

            DetailsTopicViewModel detailsTopic = new DetailsTopicViewModel() {
                Id = topic.Id,
                Title = topic.Title,
                Description = topic.Description,
                Created = topic.Created,
                Threads = new List<ThreadOne>()
            };

            foreach (var item in topic.Threads)
            {
                detailsTopic.Threads.Add(item);
            }

            return View(detailsTopic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTopicViewModel viewModelTopic)
        {
            if (ModelState.IsValid)
            {
                Topic topic = new Topic()
                {
                    Title = viewModelTopic.Title,
                    Description = viewModelTopic.Description,
                    Created = DateTime.Now,
                };

                _context.Add(topic);
                await _context.SaveChangesAsync();
                TempData["success"] = "Topic created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModelTopic);
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Created")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Topic updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
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
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Topics == null)
            {
                return Problem("Entity set 'ForumDbContext.Topics'  is null.");
            }
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
            }
            
            await _context.SaveChangesAsync();
            TempData["success"] = "Topic deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
          return (_context.Topics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
