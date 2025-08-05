using SimpleLibraryManagement.Models;

namespace SimpleLibraryManagement.Services
{
    public interface ILibraryService
    {
        void AddBook(Book book);
        void BorrowBook(int bookId, int memberId);
        void PrintAllBooks();
        void PrintAllBorrowRecords();
        void PrintAllMembers();
        void RegisterMember(Member member);
        void ReturnBook(int bookId, int memberId);
    }
}