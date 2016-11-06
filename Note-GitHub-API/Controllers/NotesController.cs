using Note_GitHub_API.Models;
using Note_GitHub_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Note_GitHub_API.Controllers
{
    public class NotesController : ApiController
    {
        #region Session

        /// <summary>
        /// NoteRepository object for user session.
        /// -- There are several more options for datasources in this application (Database, Web cache, Application variable, etc.).
        /// -- This seemed easiest for a simiple application, but would need to reconsider for high traffic or shared note collections.
        /// </summary>
        NoteRepository _repository
        {
            get
            {
                return (NoteRepository)HttpContext.Current.Session[NoteRepository.SESSION_KEY];
            }
            set
            {
                HttpContext.Current.Session[NoteRepository.SESSION_KEY] = value;
            }
        }

        #endregion

        #region GET

        /// <summary>
        /// GET /api/notes
        /// Gets all Notes.
        /// </summary>
        /// <returns>Collection of Note objects</returns>
        [HttpGet]
        public List<Note> Get()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// GET /api/notes/{id}
        /// Gets Note with specified Id.
        /// </summary>
        /// <param name="id">Id of the desired Note</param>
        /// <returns>Desired Note object, or null if not found</returns>
        [HttpGet]
        public Note Get(int id)
        {
            return _repository.Get(id);
        }

        /// <summary>
        /// GET /api/notes?query={body}
        /// Gets Notes that have a body containing the specified string.
        /// </summary>
        /// <param name="query">String to search for in Note body</param>
        /// <returns>Collection of Notes that have a body containing the specified string.</returns>
        [HttpGet]
        public List<Note> Get(string query)
        {
            return _repository.Get(query);
        }

        #endregion

        #region POST

        /// <summary>
        /// POST /api/notes 
        /// Creates a new Note object and adds it to the NoteStore collection.
        /// </summary>
        /// <param name="note">New Note object containing new body</param>
        /// <returns>The added Note object</returns>
        [HttpPost]
        public Note Post(Note note)
        {
            return _repository.Add(note);
        }

        #endregion
    }
}
