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
        public int Id { get; set; }
        public string Title  { get; set; }
        public string Author  { get; set; }
        public bool IsAvailable { get; set; }
    }
}
