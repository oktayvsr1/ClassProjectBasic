namespace LibraryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryManagement mng= new LibraryManagement();
            mng.getAllAuthors().ForEach(a => Console.WriteLine(a.authorId + " " + a.name + " " + a.surname));
        }
    }
}
