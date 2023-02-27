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
using System.Windows.Threading;
using System.Windows;
using System.Diagnostics;

namespace NotesKrizak.ViewModel
{
    public class NotesViewModel : ViewModelBase
    {
        public ObservableCollection<NoteModel> userNotes { get; set; }
        public ICommand NavigateCreateNote { get; }
        public ICommand OpenNote { get; }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public NotesViewModel(NavigationStore navigationStore) 
        {
            userNotes = new ObservableCollection<NoteModel>();
            OnLoad(navigationStore);
            NavigateCreateNote = new NavigateCreateNote(navigationStore);
            
        }

        public void OnLoad(NavigationStore navigationStore)
        {
            SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
            SQLiteCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "SELECT * From Notes ORDER BY ID desc";
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                var note = new NoteModel
                {
                    ID = "",
                    noteTitle = "",
                    noteContent = "",
                    noteCreationDate = "",
                };
                note.ID = reader["ID"] != null ? reader["ID"].ToString() : null;
                note.noteTitle = reader["Title"] != null ? reader["Title"].ToString() : null;
                note.noteContent = reader["Content"] != null ? reader["Content"].ToString() : null;
                note.noteCreationDate = reader["CreationDate"] != null ? reader["CreationDate"].ToString() : null;
                note.OpenNote = new OpenNote(navigationStore);
                try
                {
                    Application.Current.Dispatcher.Invoke(() => userNotes.Add(note));
                } catch (System.NullReferenceException)
                {
                    Debug.WriteLine("prazdny note");
                }   
            }
        }
    }
}
