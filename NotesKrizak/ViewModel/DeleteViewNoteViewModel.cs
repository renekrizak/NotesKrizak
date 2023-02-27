using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesKrizak.Commands;
using NotesKrizak.Store;


namespace NotesKrizak.ViewModel
{
    public class DeleteViewNoteViewModel : ViewModelBase
    {
        public static string ID;
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public DeleteViewNoteViewModel(NavigationStore navigationStore, string id) 
        {
            ID = id;
        }





    }
}
