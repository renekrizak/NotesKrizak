using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesKrizak.Model
{
    public class NoteModel
    {
        public int ID { get; set; }
        public string noteTitle { get; set; }
        public string noteContent { get; set; }

        public DateTime noteCreationDate { get; set; }


    }
}
