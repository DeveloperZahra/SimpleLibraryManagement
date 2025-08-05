namespace SimpleLibraryManagement.Repositories
{
    public interface IBookRepository
    {
        void AddBook(LibraryBook Book);
        List<LibraryBook> GetAllBooks();
        LibraryBook GetBook(int id);
        void UpdateBook(LibraryBook Book);
    }
}