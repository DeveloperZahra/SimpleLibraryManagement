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
        private static string BookFilePath = "books.json";
        private static string MemberFilePath = "members.json";
        private static string BorrowRecordFilePath = "BorrowRecords.json";

        public static List<Book> LoadBooks()
        {
            if (!File.Exists(BookFilePath))
                return new List<Book>();

            var json = File.ReadAllText(BookFilePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }

        public static void SaveBooks(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(BookFilePath, json);
        }


        public static List<Member> LoadMembers()
        {
            if (!File.Exists(MemberFilePath))
                return new List<Member>();

            var json = File.ReadAllText(MemberFilePath);
            return JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
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
