using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance;

        public static DependencyResolver Instance {
            get{
                if (_instance is null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }

          

        #endregion

        //public INotesDAO NotesDAO => new NotesSqlDAO();

        //public INotesLogic NotesLogic => new NotesLogic(NotesDAO);
    }
}
