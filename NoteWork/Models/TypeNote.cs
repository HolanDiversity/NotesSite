using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteWork.Models
{
    public class TypeNote
    {
        public int Id { get; set; }
        public string NameType { get; set; }

        public List<Note> Notes { get; set; }
        public TypeNote()
        {
            Notes = new List<Note>();
        }
    }
}
