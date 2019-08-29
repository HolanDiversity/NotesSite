using Microsoft.AspNetCore.Mvc;
using NoteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteWork.Controllers.Functional
{
    public class CreateFunc : Controller
    {
        private NotesContext db;
        public CreateFunc(NotesContext context)
        {
            db = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            db.Notes.Add(note);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
