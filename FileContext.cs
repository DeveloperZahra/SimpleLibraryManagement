using SimpleLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleLibraryManagement
{
    // Static class responsible for handling file operations such as saving and loading data
    public static class FileContext
    {
        private static string BookFilePath = "books.json"; // Path to the file where book data will be stored or loaded from
        private static string MemberFilePath = "members.json"; // Path to the file where member data will be stored or loaded from
        private static string BorrowRecordFilePath = "BorrowRecords.json"; // Path to the file where borrow record data will be stored or loaded from

        // Loads the list of books from the JSON file
        public static List<Book> LoadBooks()
        {
            // Check if the books file exists; if not, return an empty list
            if (!File.Exists(BookFilePath))
                return new List<Book>();

            var json = File.ReadAllText(BookFilePath); // Read the entire content of the file as a JSON string
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>(); // Deserialize the JSON string into a list of Book objects
                                                                                     // If deserialization fails or returns null, return an empty list
        }


        // Saves the list of books to the JSON file
        public static void SaveBooks(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books); // Convert the list of Book objects to a JSON string
            File.WriteAllText(BookFilePath, json); // Write the JSON string to the file, overwriting any existing content
        }

        // Load the list of member form the JSON file 
        public static List<Member> LoadMembers() 
        {
            // Check if the members file exists; if it doesn't, return an empty list
            if (!File.Exists(MemberFilePath))
                return new List<Member>();

            var json = File.ReadAllText(MemberFilePath);  // Read the entire content of the members file as a JSON string
            return JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>(); // Deserialize the JSON string into a list of Member objects
                                                                                         // If deserialization fails or returns null, return an empty list
        }
        public static void SaveMembers(List<Member> members)
        {
            var json = JsonSerializer.Serialize(members);
            File.WriteAllText(MemberFilePath, json);
        }

        //to load and save BorrowRecord data to file ...
        public static List<BorrowRecord> LoadBorrowRecords()
        {
            if (!File.Exists(BorrowRecordFilePath))
                return new List<BorrowRecord>();

            var json = File.ReadAllText(BorrowRecordFilePath);
            return JsonSerializer.Deserialize<List<BorrowRecord>>(json) ?? new List<BorrowRecord>();
        }
        public static void SaveBorrowRecords(List<BorrowRecord> BorrowRecords)
        {
            var json = JsonSerializer.Serialize(BorrowRecords);
            File.WriteAllText(BorrowRecordFilePath, json);
        }


    }
}
