using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteWork.Controllers.Functional
{
    public class EditFunc : Controller
    {
        private NotesContext db;
        public EditFunc(NotesContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Note note = await db.Notes.FirstOrDefaultAsync(p => p.Id == id);
                if (note != null)
                    return View(note);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Note phone)
        {
            db.Notes.Update(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
