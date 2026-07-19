using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembers();

        Task<Member?> GetMemberById(int id);

        Task<int> AddMember(Member member);

        Task<int> UpdateMember(Member member);

        Task<int> DeleteMember(int id);
    }
}