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
            _BookRepository.AddBook(book); // Call the AddBook method from the book repository to save the book
        }

        
       public  void RegisterMember(Member member) // Registers a new member in the system using the member repository
        {
            _MemberRepository.AddMember(member); // Call the AddMember method from the member repository to store the member data
        }


        // Allows a member to borrow a book if it's available
        public void BorrowBook(int bookId, int memberId)
        {
            var book = _BookRepository.GetBookById(bookId); // Retrieve the book by its ID from the repository
            var member = _MemberRepository.GetMemberById(memberId);  // Retrieve the member by their ID from the repository
            if (book != null && member != null && book.IsAvailable) // Proceed only if the book and member exist and the book is available
            {
                var borrowRecord = new BorrowRecord  // Create a new borrow record
                {
                    BookId = book.BookId, // ID of the borrowed book
                    MemberId = member.MemberId, // ID of the borrowing member
                    BorrowDate = DateTime.Now,  // Current date/time as borrow date
                    ReturnDate = null  // Return date is null until book is returned
                };
                _BorrowRecordRepository.AddBorrowRecord(borrowRecord);  // Save the borrow record to the system
                _BookRepository.UpdateBookAvailable(book.BookId);   // Update the book's availability status to unavailable
                Console.WriteLine($"Book '{book.Title}' borrowed by member '{member.Name}'.");    // Display success message
                Additional.HoldScreen();//to hold the screen for user to see the message
            }
            else
            {
                throw new Exception("Book is not available or member does not exist.");  // Throw an exception if the book is not available or the member/book doesn't exist
                Additional.HoldScreen();//to hold the screen for user to see the message
            }
        }


        // Allows a member to return a borrowed book
        public void ReturnBook(int bookId, int memberId)
        {
            var book = _BookRepository.GetBookById(bookId); // Retrieve the book by its ID from the repository
            var member = _MemberRepository.GetMemberById(memberId);     // Retrieve the member by their ID from the repository

            if (book != null && member != null)   // Check that both the book and the member exist
            {
                // Search for an active borrow record (not yet returned) for the given book and member
                var borrowRecord = _BorrowRecordRepository.GetAllBorrowRecords()
                    .FirstOrDefault(br => br.BookId == book.BookId && br.MemberId == member.MemberId && br.ReturnDate == null);

                if (borrowRecord != null)    // If a matching borrow record is found
                {
                    _BorrowRecordRepository.UpdateReturnDate(borrowRecord.BorrowRecordId, DateTime.Now);    // Update the return date in the borrow record to the current date/time
                    _BookRepository.UpdateBookAvailable(book.BookId);  // Mark the book as available again
                    Console.WriteLine($"Book '{book.Title}' returned by member '{member.Name}'."); // Inform the user of the successful return
                    Additional.HoldScreen();//to hold the screen for user to see the message
                }
                else
                {
                    throw new Exception("No active borrow record found for this book and member.");   // If no matching borrow record found, display an error message
                    Additional.HoldScreen();//to hold the screen for user to see the message
                }
            }
            else
            {
                throw new Exception("Book or member does not exist.");  // If either the book or member does not exist, throw an exception
            }
        }


       
        public void PrintAllBooks()
        {
            var books = _BookRepository.GetAllBooks();  // Retrieve all books from the repository
            if (books.Count == 0)  // Check if the library has no books
            {
                Console.WriteLine("No books available in the library.");  // Inform the user that there are no books
            }
            else
            {
                Console.WriteLine("Books in the library:");  // Display header for book list

                // Loop through and display details of each book
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.BookId}\n" +
                                      $"Title: {book.Title}\n" +
                                      $"Author: {book.Author}\n" +
                                      $"Available: {book.IsAvailable}");
                }
            }
        }

        // Displays a list of all registered library members
        public void PrintAllMembers()
        {
            var members = _MemberRepository.GetAllMembers();   // Retrieve all members from the member repository
            if (members.Count == 0)   // Check if there are no members in the system
            {
                Console.WriteLine("No members registered in the library."); // Inform the user that no members are registered
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
