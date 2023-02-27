using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesKrizak.Model
{
    public class NoteModel
    {
        public string ID { get; set; }
        public string noteTitle { get; set; }
        public string noteContent { get; set; }

        public string noteCreationDate { get; set; }

        public ICommand OpenNote { get; set; }


    }
}
