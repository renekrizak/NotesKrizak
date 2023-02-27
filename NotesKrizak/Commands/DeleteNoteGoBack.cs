using NotesKrizak.Store;
using NotesKrizak.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesKrizak.Commands
{
    public class DeleteNoteGoBack : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public static string id;

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public DeleteNoteGoBack(NavigationStore navigationStore, string ID)
        {
            _navigationStore = navigationStore;
            id= ID;
        }

        public override void Execute(object parameter)
        {
            SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
            SQLiteCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "DELETE FROM Notes where ID=" + id;
            cmd.ExecuteNonQuery();

            _navigationStore.CurrentViewModel = new NotesViewModel(_navigationStore);
        }
    }
}
