using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesKrizak.ViewModel;
using NotesKrizak.Store;

namespace NotesKrizak.Commands
{
    public class NavigateNoteView : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateNoteView(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new NotesViewModel(_navigationStore);
        }
    }
}
