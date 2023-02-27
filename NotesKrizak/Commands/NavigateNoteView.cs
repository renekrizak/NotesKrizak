using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesKrizak.ViewModel;
using NotesKrizak.Store;
using System.Configuration;
using System.Data.SQLite;
using System.Globalization;

namespace NotesKrizak.Commands
{
    public class NavigateNoteView : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateNoteView(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public override void Execute(object parameter)
        {
            var values = (object[])parameter;
            string title = (string)values[0];
            string content = (string)values[1];
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string date = dt.ToString();
            SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
            SQLiteCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "INSERT INTO Notes(Title, Content, CreationDate) VALUES (@title, @content, @creationdate)";
            cmd.Parameters.Add(new SQLiteParameter("@title", title));
            cmd.Parameters.Add(new SQLiteParameter("@content", content));
            cmd.Parameters.Add(new SQLiteParameter("@creationdate", date));
            cmd.ExecuteNonQuery();
            _navigationStore.CurrentViewModel = new NotesViewModel(_navigationStore);
        }
    }
}
