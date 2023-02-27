using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesKrizak.ViewModel;
using NotesKrizak.Store;
using System.Data.SQLite;

namespace NotesKrizak.Commands
{
    public class OpenNote : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public OpenNote(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            string value = (string)parameter;
            
            _navigationStore.CurrentViewModel = new DeleteViewNoteViewModel(_navigationStore, value);
        }
    }
}
