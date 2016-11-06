using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_GitHub_API.Models
{
    public class Note
    {
        #region Members

        /// <summary>
        /// Id of the note.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Body of the note.
        /// </summary>
        public string Body { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Note()
        {
            Id = -1;
        }

        /// <summary>
        /// Constructor overload with data.
        /// </summary>
        /// <param name="id">Id of new Note object</param>
        /// <param name="body">Body of new Note object</param>
        public Note(int id, string body)
        {
            Id = id;
            Body = body;
        }

        #endregion
    }
}
