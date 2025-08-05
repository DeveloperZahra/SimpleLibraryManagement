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

     

        public static int MemberCount = 0; // Static variable to keep track of the total number of members created
        public Member()
        {
            MemberCount++;
            MemberId = MemberCount;
        }
    }

}

