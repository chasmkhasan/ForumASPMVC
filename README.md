# Anonymt forum
Our thinking was we will build one team project where we build a Forum. User may able to create their own subjectss (Ex. School, Sport, File, Enviornment). Under the topics user may able to create own topics under above subject. Under the Topcs users may able to start their own conversation. They may have start give comment, reply or create new topics.

## Structure of Project:
|   Tasks     |   Framwork    |  Effect  |
|-----|--------|-------|
|C#  |  ASP.Net   | wwwroot
|MVC |  Model, View, Controller   | Fetching Data
|Model |  Classes   | Fetching Data
|View |  Partial View, View Model, CRUD   | Fetching Data
|Controller |  HTTP Post, HTTP Create, HTTP Delete, HTTP Edit   | Fetching Data
|EF |  Entity Framework   | 
|Database |   SQL   | LocalDatabase
|Connection |  JSON   |  Global Datbase

## Key features
|Feature     |Status    |
|-----|:--------:|
|School, Sports, Film, AdditionalTopice |:white_check_mark:     |
|Thread, Comment, Reply | :white_check_mark:    |
|ViewModel, PartialView, CRUD|:white_check_mark:     |

## Sample of Code Structure - CommentsController - HTTPPost
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
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Topics", new { id = comment.ThreadOneId });
            }
            ViewData["ThreadOneId"] = new SelectList(_context.ThreadOnes, "Id", "Id", createCommentViewModel.ThreadOneId);
            return View(createCommentViewModel);
        }

## Team
- [Md. Kamrul Hasan](https://github.com/chasmkhasan)
- [Reza](https://github.com/Rezaeskandar)
- [Md Ruhul Amin](https://github.com/Md-Ruhul-Amin-Rony)
- [Tasmia Zahin](https://github.com/tasmiazahin)
