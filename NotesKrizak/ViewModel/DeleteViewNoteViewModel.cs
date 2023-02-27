using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesKrizak.Commands;
using NotesKrizak.Model;
using NotesKrizak.Store;
using System.Data.SQLite;
using System.Windows;
using System.Diagnostics;
using System.Windows.Input;

namespace NotesKrizak.ViewModel
{
    public class DeleteViewNoteViewModel : ViewModelBase
    {
        public ObservableCollection<NoteModel> userNotes { get; set; }
        public ICommand NavigateBackNoteView { get; }
        public ICommand DeleteNoteGoBack { get; }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public DeleteViewNoteViewModel(NavigationStore navigationStore, string id) 
        {
            userNotes = new ObservableCollection<NoteModel>();
            OnLoad(id);
            NavigateBackNoteView = new NavigateBackNoteView(navigationStore);
            DeleteNoteGoBack = new DeleteNoteGoBack(navigationStore, id);
        }

        public void OnLoad(string id)
        {
            SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
            SQLiteCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "SELECT Title, Content, CreationDate FROM Notes WHERE ID=" + id;
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();
            var note = new NoteModel
            {
                ID = "",
                noteTitle = "",
                noteContent = "",
                noteCreationDate = "",
            };
            note.ID = id;
            note.noteTitle = reader["Title"] != null ? reader["Title"].ToString() : null;
            note.noteContent = reader["Content"] != null ? reader["Content"].ToString() : null;
            note.noteCreationDate = reader["CreationDate"] != null ? reader["CreationDate"].ToString() : null;
            Debug.WriteLine(note.ID);
            Debug.WriteLine(note.noteTitle);
            Debug.WriteLine(note.noteContent);
            Debug.WriteLine(note.noteCreationDate);
            Application.Current.Dispatcher.Invoke(() => userNotes.Add(note));

        }
    }
}
