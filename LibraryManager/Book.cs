using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class Book
    {
        public int bookId { get; set; }
        public int authotId { get; set; }
        public string title  { get; set; }
        public int pages { get; set; }
        public int categoryId { get; set; }

        public Book(int bookId, int authotId, string title, int pages, int categoryId)
        {
            this.bookId = bookId;
            this.authotId = authotId;
            this.title = title;
            this.pages = pages;
            this.categoryId = categoryId;
        }
    }
}
