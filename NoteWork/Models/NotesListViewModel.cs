using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteWork.Models
{
    public class NotesListViewModel
    {
        public IEnumerable<Note> Notes { get; set; }
        public string Name { get; set; }
        public SelectList TypeNotes { get; set; }
    }
}
