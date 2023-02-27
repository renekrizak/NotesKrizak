using NotesKrizak.Store;
using NotesKrizak.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesKrizak.Commands
{
    public class NavigateBackNoteView : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateBackNoteView(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new NotesViewModel(_navigationStore);
        }
    }
}
