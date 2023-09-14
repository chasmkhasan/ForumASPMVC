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
using NuGet.Versioning;

namespace ForumASPMVC.Controllers
{
    public class RepliesController : Controller
    {
        private readonly ForumDbContext _context;

        public RepliesController(ForumDbContext context)
        {
            _context = context;
        }

        // GET: Replies/Create
        public IActionResult Create()
        {
            ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id");
            return View();
        }

        // POST: Replies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReplyViewModel createReplyViewModel)
        {
            if (ModelState.IsValid)
            {
                Reply reply = new Reply
                {
                    Text = createReplyViewModel.Text,
                    CommentId = createReplyViewModel.CommentId,
                    Created = DateTime.Now,

                };
                _context.Add(reply);

                var comment = _context.Comments.Where(c => c.Id == reply.CommentId).FirstOrDefault();

                var thread = _context.ThreadOnes.Where(t=>t.Id== comment.ThreadOneId).FirstOrDefault();

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Topics", new { id = thread.TopicId });
            }
            ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id", createReplyViewModel.CommentId);
            return View(createReplyViewModel);
        }

        // GET: Replies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Replies == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id", reply.CommentId);
            return View(reply);
        }
    }
}
