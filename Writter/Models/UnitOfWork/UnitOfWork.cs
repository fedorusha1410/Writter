using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writter.Models.Repository;
using Writter.ViewModels;

namespace Writter.Models.UnitOfWork
{
    class UnitOfWork 
    {
        private WritterModel db = new WritterModel();

      
        private NoteRepository noteRepository;
        private UserRepository userRepository;
        private StyleRepository styleRepository;

        public UserRepository User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public NoteRepository Note
        {
            get
            {
                if (noteRepository == null)
                    noteRepository = new NoteRepository(db);
                return noteRepository;
            }
        }

        public StyleRepository Style
        {
            get
            {
                if (styleRepository == null)
                    styleRepository = new StyleRepository(db);
                return styleRepository;
            }
        }

    }
}
