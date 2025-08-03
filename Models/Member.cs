using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Models
{
    // This class represents a library member
    public class Member
    {
        public int MemberId { get; private set; } // Unique identifier for each member (set privately, read-only from outside)
        public string Name { get;  set; }    // Name of the member

        // Constructor to initialize the member with ID and Name
        public Member(int id, string name)
        {
            MemberId = id;
            Name = name;
        }
    }
}
