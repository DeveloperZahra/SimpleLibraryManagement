using SimpleLibraryManagement.Repositories;
using SimpleLibraryManagement.Services;

namespace SimpleLibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBookRepository bookRepository = new BookRepository(); // Create an instance of the BookRepository using the IBookRepository interface
            IMemberRepository memberRepository = new MemberRepository(); // Create an instance of the MemberRepository using the IMemberRepository interface
            IBorrowRecordRepository borrowRecordRepository = new BorrowRecordRepository();
            ILibraryService libraryService = new LibraryService(bookRepository, memberRepository, borrowRecordRepository); 



        }
    }
}
