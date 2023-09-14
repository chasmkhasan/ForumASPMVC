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
    public class CommentsController : Controller
    {
        private readonly ForumDbContext _context;

        public CommentsController(ForumDbContext context)
        {
            _context = context;
        }

    

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["ThreadOneId"] = new SelectList(_context.ThreadOnes, "Id", "Id");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCommentViewModel createCommentViewModel)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment
                {
                    Title = createCommentViewModel.Title,
                    Text = createCommentViewModel.Text,
                    ThreadOneId = createCommentViewModel.ThreadOneId,
                    Created = DateTime.Now,
                };
                _context.Add(comment);
                var thread = _context.ThreadOnes.Where(t => t.Id == comment.ThreadOneId).FirstOrDefault();
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Topics", new { id = thread.TopicId });
            }
            ViewData["ThreadOneId"] = new SelectList(_context.ThreadOnes, "Id", "Id", createCommentViewModel.ThreadOneId);
            return View(createCommentViewModel);
        }
    }
}
