using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoteWork.Models;

namespace NoteWork.Controllers
{
    public class HomeController : Controller
    {

        private NotesContext db;
        public HomeController(NotesContext context)
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


        public ActionResult Index(int? typenote, string name)
        {
            IQueryable<Note> notes = db.Notes.Include(p => p.TypeNote);
            if (typenote != null && typenote != 0)
            {
                notes = notes.Where(p => p.TypeNoteId == typenote);
            }
            if (!String.IsNullOrEmpty(name))
            {
                notes = notes.Where(p => p.ThisNote.Contains(name));
            }

            List<TypeNote> typenotes = db.TypeNotes.ToList();

            typenotes.Insert(0, new TypeNote { NameType = "Все", Id = 0 });

            NotesListViewModel viewModel = new NotesListViewModel
            {
                Notes = notes.ToList(),
                TypeNotes = new SelectList(typenotes, "Id", "NameType"),
                Name = name
            };
            return View(viewModel);
        }
    }
}
