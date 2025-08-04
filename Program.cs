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
            IBorrowRecordRepository borrowRecordRepository = new BorrowRecordRepository(); // Create an instance of the BorrowRecordRepository using the IBorrowRecordRepository interface
            ILibraryService libraryService = new LibraryService(bookRepository, memberRepository, borrowRecordRepository); // Create an instance of the LibraryService, injecting the repositories


            char choice;
            bool exit = true;
            do
            {
              

                Console.Clear(); // Clear the console screen before displaying the main menu

                Console.WriteLine("====Welcome to the Library Management System===="); // Display the system title

               //to display library system menu options
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Register Member");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. View All Books");
                Console.WriteLine("6. View All Members");
                Console.WriteLine("7. View All Borrow Records");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Please enter your choice: "); // Prompt the user to enter a choice

                // Read a single character from user input and parse it to a `char`
                // Assumes user enters a valid character representing the choice (e.g., '1', '2', etc.)
                choice = char.Parse(Console.ReadLine());


                //to call the appropriate method based on user choice
                switch (choice)
                {

                    case '1':
                        //to get user input for adding a book ...
                        string title = Validation.StringNamingValidation("Book Title");
                        string author = Validation.StringNamingValidation("Book Author");

                        //to create a new book object ...
                        Models.Book NewBook = new Models.Book();
                        NewBook.Title = title;
                        NewBook.Author = author;
                        NewBook.IsAvailable = true;
                        //to add the book using library service
                        libraryService.AddBook(NewBook);
                        Console.WriteLine("Book added successfully.");
                        Additional.HoldScreen();//to hold the screen for user to see the message
                        break;

                    case '2':
                        //to get user input for registering a member ...
                        string memberName = Validation.StringNamingValidation("Member name");
                        //to create a new member object ...
                        Models.Member NewMember = new Models.Member();
                        NewMember.Name = memberName;
                        //to register the member using library service
                        libraryService.RegisterMember(NewMember);
                        Console.WriteLine("Member registered successfully.");
                        Additional.HoldScreen();//to hold the screen for user to see the message
                        break;


                    case '3':
                        //to get user input for borrowing a book ...
                        int bookIdToBorrow = Validation.IntValidation("Book ID to borrow");
                        int memberIdToBorrow = Validation.IntValidation("Member ID to borrow the book");
                        libraryService.BorrowBook(bookIdToBorrow, memberIdToBorrow);
                        break;

                    case '4':
                        int bookIdToReturn = Validation.IntValidation("Book ID to return");
                        int memberIdToReturn = Validation.IntValidation("Member ID to return the book");
                        libraryService.ReturnBook(bookIdToReturn, memberIdToReturn);
                        break;

                    case '5':
                        libraryService.PrintAllBooks();
                        Additional.HoldScreen();//to hold the screen for user to see the message
                        break;

                    case '6':
                        libraryService.PrintAllMembers();
                        Additional.HoldScreen();//to hold the screen for user to see the message
                        break;

                    case '7':
                        libraryService.PrintAllBorrowRecords();
                        Additional.HoldScreen();//to hold the screen for user to see the message
                        break;

                    case '0':
                        exit = false;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        Additional.HoldScreen();//to hold the screen for user to see the message
                        break;
                }

            } while (exit);


        }
            
    }
}
