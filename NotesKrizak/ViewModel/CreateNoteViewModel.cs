using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesKrizak.Commands;
using System.Windows.Input;
using NotesKrizak.Store;


namespace NotesKrizak.ViewModel
{
    public class CreateNoteViewModel : ViewModelBase
    {
        public ICommand NavigateNoteView { get; }
        public ICommand NavigateBackNoteView { get; }

        public CreateNoteViewModel(NavigationStore navigationStore)
        {
            NavigateNoteView = new NavigateNoteView(navigationStore);
            NavigateBackNoteView = new NavigateBackNoteView(navigationStore);
        }
    }
}
