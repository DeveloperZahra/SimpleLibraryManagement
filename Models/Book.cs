using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Models
{
    // This class represents a book in the library system
    public class Book 
    {
        public int Id { get; set; }  // Unique identifier for each book
        public string Title  { get; set; }  // Title of the book
        public string Author  { get; set; }   // Author of the book
        public bool IsAvailable { get; set; } // Indicates whether the book is currently available for borrowing
    }
}
