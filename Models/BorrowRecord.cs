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
        public int MemberId { get; set; } 
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; } 


    }
}
