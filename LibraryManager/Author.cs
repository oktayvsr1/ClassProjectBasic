using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class Author
    {
        public int authorId { get; set; }
        public string  name { get; set; }
        public string surname { get; set; }

        public Author(int authorId, string name, string surname)
        {
            this.authorId = authorId;
            this.name = name;
            this.surname = surname;
        }
    }
}
