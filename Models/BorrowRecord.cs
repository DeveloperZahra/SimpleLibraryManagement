using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Models
{
    // This class represents a record of a book being borrowed by a member
    public class BorrowRecord
    {
        public int BRId { get; set; }   // Unique identifier for the borrow record
        public int MemberId { get; set; } // ID of the member who borrowed the book
        public int BookId { get; set; }     // ID of the book being borrowed
        public DateTime BorrowDate { get; set; }    // Date when the book was borrowed
        public DateTime ReturnDate { get; set; } // Expected return date of the borrowed book
        public static int BorrowRecordCount = 0; // Static variable to keep track of the total number of borrow records created
        public BorrowRecord() // Constructor for the BorrowRecord class
        {
            BorrowRecordCount++;
            BRId = BorrowRecordCount;
        }


    }
}
