using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteWork.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string NameNote { get; set; }
        public string Img { get; set;}
        public string ThisNote { get; set; }
        public int TypeNoteId { get; set; }
        public TypeNote TypeNote { get; set; }
        
    }
}
