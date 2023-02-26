using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesKrizak.Store;
using System.Collections.ObjectModel;
using NotesKrizak.Model;
using System.Configuration;
using System.Data.SQLite;
using NotesKrizak.Commands;
using System.Windows.Input;

namespace NotesKrizak.ViewModel
{
    public class NotesViewModel : ViewModelBase
    {
        public ObservableCollection<NoteModel> userNotes { get; set; }
        public ICommand NavigateCreateNote { get; }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public NotesViewModel(NavigationStore navigationStore) 
        {
            NavigateCreateNote = new NavigateCreateNote(navigationStore);
        }

        public void OnLoad()
        {
            SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
            SQLiteCommand cmd = conn.CreateCommand();
            conn.Open();

        }
    }
}
