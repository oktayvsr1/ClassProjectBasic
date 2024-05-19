using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManager
{
    public class LibraryManagement : ILibraryManagement
    {
        public SqlConnection getConnected()
        {
            string conString = @"Server=OKTAY\SQLEXPRESS03;Database=LibraryManagement;Trusted_Connection=true;TrustServerCertificate=true";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            return connection;
        }
        public void addAuthor(Author a)
        {
            SqlConnection con = getConnected();
            string query = "insert into authors values(@authorId,@name,@surname)";
            SqlCommand cmd= new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@authorId",a.authorId);
            cmd.Parameters.AddWithValue("@name", a.name);
            cmd.Parameters.AddWithValue("@surname", a.surname);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void addBook(Book b)
        {
            SqlConnection con = getConnected();
            string query = "insert into books values(@bookId,@authorId,@title,@pages,@categoryId)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@bookId", b.bookId);
            cmd.Parameters.AddWithValue("@authorId",b.authotId);
            cmd.Parameters.AddWithValue("@title", b.title);
            cmd.Parameters.AddWithValue("@pages", b.pages);
            cmd.Parameters.AddWithValue("@categoryId", b.categoryId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteAuthor(int id)
        {
            SqlConnection conn = getConnected();
            string query = "delete from auhors where authorId=@id";
            SqlCommand cmd=new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@authorId",id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteBook(int id)
        {
            SqlConnection conn = getConnected();
            string query = "delete from books where bookId=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@bookId", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Author> getAllAuthors()
        {
            List<Author> authors = new List<Author>();
            SqlConnection conn = getConnected();
            string query = "select * from authors";
            SqlCommand cmd= new SqlCommand(query, conn);

            SqlDataReader reader= cmd.ExecuteReader();
            while (reader.Read())
            {
                Author author = new Author(reader.GetInt32(0),reader.GetString(1),reader.GetString(2));
                authors.Add(author);

            }
            return authors;
        }

        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            SqlConnection conn = getConnected();
            string query = "select * from books";
            SqlCommand cmd= new SqlCommand(query, conn);    
            SqlDataReader reader= cmd.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book(reader.GetInt32(0),reader.GetInt32(1),reader.GetString(2),reader.GetInt32(30),reader.GetInt32(4));
                books.Add(book);
            }
            return books;
        }

        public void updateAuthor(int id, string name, string surname)
        {
            SqlConnection con = getConnected();
            string query = "update authors set name=@name,surname=@surname where authorId=@id";
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@authorId",id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateBook(int bookId, string title, int pages)
        {
            SqlConnection con = getConnected();
            string query = "update books set title=@title,pages=@pages where bookId=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@bookId", bookId);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@pages", pages);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
    }
}
