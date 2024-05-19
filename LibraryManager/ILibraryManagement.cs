using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public interface ILibraryManagement
    {
        public List<Author> getAllAuthors();
        public List<Book> getAllBooks();
        public void addBook(Book b);
        public void addAuthor(Author a);
        public void deleteAuthor(int id);
        public void deleteBook(int id);
        public void updateAuthor(int id,string name,string surname);
        public void updateBook(int bookId,string title,int pages); 

    }
}
