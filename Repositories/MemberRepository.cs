using SimpleLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member member)
        {
            var Members = GetAllMembers();
            Members.Add(member);
            FileContext.SaveMembers(Members);

        }

        public Member GetMember(int Memberid)
        {
            return GetAllMembers().FirstOrDefault(m => m.Memberid == Memberid);
        }


        public void UpdateMembers(Member member)
        {
            var Members = GetAllMembers();
            var index = Members.FindIndex(m => m.Memberid == Memberid);
            if (index == -1)
            {
                Members.[index] = member;
                FileContext.SaveAllMembers(Members);
            }

        }

        public List<Member> GetAllMembers()
        {
            return FileContext.LoadMembers();

        }



    }
}
