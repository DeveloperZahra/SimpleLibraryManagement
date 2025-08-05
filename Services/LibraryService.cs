using SimpleLibraryManagement.Models;
using SimpleLibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Services
{
    public  class LibraryService 
    {
        private readonly IBookRepository _BookRepository; // Reference to the book repository used for managing book-related data (e.g., add, get, update books)
        private readonly IMemberRepository _MemberRepository; // Reference to the member repository used for handling member-related operations (e.g., register, retrieve members)
        private readonly IBorrowRecordRepository _BorrowRecordRepository; // Reference to the borrow record repository used for managing borrow/return transactions and history

        // Constructor for the LibraryService class
        // Uses dependency injection to initialize the repositories
        public LibraryService(IBookRepository book_repository, IMemberRepository memberRepository, IBorrowRecordRepository borrowRecordRepository)
        {
            _BookRepository = book_repository; // Assign the injected book repository to the private field
            _MemberRepository = memberRepository;  // Assign the injected member repository to the private field
            _BorrowRecordRepository = borrowRecordRepository; // Assign the injected borrow record repository to the private field
        }

        public void AddBook(Book book) // Adds a new book to the system using the book repository
        {
            _BookRepository.AddBook(book);
        }

        
       public  void RegisterMember(Member member)
       {
            _MemberRepository.AddMember(member);
       }


        public void BorrowBook(int bookId, int memberId)
        {
            var book = _BookRepository.GetBookById(bookId);
            var member = _MemberRepository.GetMemberById(memberId);
            if (book != null && member != null && book.IsAvailable)
            {
                var borrowRecord = new BorrowRecord
                {
                    BookId = book.BookId,
                    MemberId = member.MemberId,
                    BorrowDate = DateTime.Now,
                    ReturnDate = null
                };
                _BorrowRecordRepository.AddBorrowRecord(borrowRecord);
                _BookRepository.UpdateBookAvailable(book.BookId);
                Console.WriteLine($"Book '{book.Title}' borrowed by member '{member.Name}'.");
                Additional.HoldScreen();//to hold the screen for user to see the message
            }
            else
            {
                throw new Exception("Book is not available or member does not exist.");
                Additional.HoldScreen();//to hold the screen for user to see the message
            }
        }


        public void ReturnBook(int bookId, int memberId)
        {
            var book = _BookRepository.GetBookById(bookId);
            var member = _MemberRepository.GetMemberById(memberId);
            if (book != null && member != null)
            {
                var borrowRecord = _BorrowRecordRepository.GetAllBorrowRecords()
                    .FirstOrDefault(br => br.BookId == book.BookId && br.MemberId == member.MemberId && br.ReturnDate == null);
                if (borrowRecord != null)
                {
                    _BorrowRecordRepository.UpdateReturnDate(borrowRecord.BorrowRecordId, DateTime.Now);
                    _BookRepository.UpdateBookAvailable(book.BookId);
                    Console.WriteLine($"Book '{book.Title}' returned by member '{member.Name}'.");
                    Additional.HoldScreen();//to hold the screen for user to see the message
                }
                else
                {
                    throw new Exception("No active borrow record found for this book and member.");
                    Additional.HoldScreen();//to hold the screen for user to see the message
                }
            }
            else
            {
                throw new Exception("Book or member does not exist.");
            }
        }



        public void PrintAllBooks()
        {
            var books = _BookRepository.GetAllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
            }
            else
            {
                Console.WriteLine("Books in the library:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.BookId}\n" +
                                      $"Title: {book.Title}\n" +
                                      $"Author: {book.Author}\n" +
                                      $"Available: {book.IsAvailable}");
                }
            }
        }


        public void PrintAllMembers()
        {
            var members = _MemberRepository.GetAllMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("No members registered in the library.");
            }
            else
            {
                Console.WriteLine("Registered members:");
                foreach (var member in members)
                {
                    Console.WriteLine($"ID: {member.MemberId}\n" +
                                      $"Name: {member.Name}");
                }
            }

        }


        public void PrintAllBorrowRecords()
        {
            var borrowRecords = _BorrowRecordRepository.GetAllBorrowRecords();
            if (borrowRecords.Count == 0)
            {
                Console.WriteLine("No borrow records found.");
            }
            else
            {
                Console.WriteLine("Borrow Records:");
                foreach (var record in borrowRecords)
                {
                    Console.WriteLine($"Record ID: {record.BorrowRecordId}\n" +
                                      $"Book ID: {record.BookId}\n" +
                                      $"Member ID: {record.MemberId}\n" +
                                      $"Borrow Date: {record.BorrowDate}\n" +
                                      $"Return Date: {(record.ReturnDate.HasValue ? record.ReturnDate.Value.ToString() : "Not returned yet")}");
                }
            }
        }


    }
}
