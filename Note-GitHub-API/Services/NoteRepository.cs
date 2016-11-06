using Note_GitHub_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_GitHub_API.Services
{
    /// <summary>
    /// Note object collection manager.
    /// </summary>
    class NoteRepository
    {
        #region Members

        /// <summary>
        ///NoteRepository object session variable key.
        /// </summary>
        public const string SESSION_KEY = "NoteRepository";

        /// <summary>
        /// Collection of Note objects.
        /// </summary>
        private List<Note> NoteStore { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes NoteRepository object.
        /// </summary>
        public NoteRepository()
        {
            NoteStore = new List<Note>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds Note object to NoteStore collection. Assigns new Id to Note object based on max Id in NoteStore collection.
        /// </summary>
        /// <param name="note">The new Note object to be added.</param>
        /// <returns>The added Note object</returns>
        public Note Add(Note note)
        {
            try
            {
                //Notes in NoteStore collection start at Id of 1.
                //Could be handled by database table primary key.
                int _newId = 1;
                if (NoteStore.Count() > 0)
                {
                    //Find largest Note.Id in NoteStore and add 1. 
                    _newId = NoteStore.Max(n => n.Id) + 1;
                }
                //Assign Id to new Note object.
                note.Id = _newId;
                //Add new Note object to NoteStore collection.
                NoteStore.Add(note);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return note;
        }

        /// <summary>
        /// Gets Note object by Id.
        /// </summary>
        /// <param name="id">Id of desired Note object</param>
        /// <returns>The desired Note object, null if not found</returns>
        public Note Get(int id)
        {
            return NoteStore.FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// Gets Note object collection where the Note.Body contains query substring.
        /// </summary>
        /// <param name="query">Substring to search for</param>
        /// <returns>Collection of Note objects that contain the query substring in their body</returns>
        public List<Note> Get(string query)
        {
            return NoteStore.Where(n => n.Body.ToLower().Contains(query.ToLower())).ToList();
        }

        /// <summary>
        /// Gets all notes in the NoteStore collection.
        /// </summary>
        /// <returns>The NoteStore collection</returns>
        public List<Note> GetAll()
        {
            return NoteStore;
        }

        #endregion
    }
}
