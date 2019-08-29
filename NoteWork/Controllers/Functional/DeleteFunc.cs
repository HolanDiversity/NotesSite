using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteWork.Controllers.Functional
{
    public class DeleteFunc : Controller
    {
        private NotesContext db;
        public DeleteFunc(NotesContext context)
        {
            db = context;
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Note note = await db.Notes.FirstOrDefaultAsync(p => p.Id == id);
                if (note != null)
                {
                    db.Notes.Remove(note);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
