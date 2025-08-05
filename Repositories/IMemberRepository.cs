using SimpleLibraryManagement.Models;

namespace SimpleLibraryManagement.Repositories
{
    public interface IMemberRepository
    {
        void AddMember(Member member);
        List<Member> GetAllMembers();
        Member GetMember(int Memberid);
        void UpdateMembers(Member member);
    }
}