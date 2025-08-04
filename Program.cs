using SimpleLibraryManagement.Repositories;
using SimpleLibraryManagement.Services;

namespace SimpleLibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBookRepository bookRepository = new BookRepository(); // Create an instance of the BookRepository using the IBookRepository interface
            IMemberRepository memberRepository = new MemberRepository();
            IBorrowRecordRepository borrowRecordRepository = new BorrowRecordRepository();
            ILibraryService libraryService = new LibraryService(bookRepository, memberRepository, borrowRecordRepository); 



        }
    }
}
