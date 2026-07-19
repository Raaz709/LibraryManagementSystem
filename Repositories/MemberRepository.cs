using Dapper;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DapperContext _context;

        public MemberRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            var query = "SELECT * FROM Members";

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<Member>(query);

        }

        public async Task<Member?> GetMemberById(int id)
        {
            var query = "SELECT * FROM Members WHERE ID = @ID";

            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Member>(query, new { ID = id });
        }

        public async Task<int> AddMember(Member member)
        {
            var query = @"INSERT INTO Members 
                  (NAME, EMAIL, PHONE)
                  VALUES
                  (@NAME, @EMAIL, @PHONE)";

            using var connection = _context.CreateConnection();

            return await connection.ExecuteAsync(query, member);
        }

        public async Task<int> UpdateMember(Member member)
        {
            var query = @"UPDATE Members
                  SET NAME = @NAME,
                      EMAIL = @EMAIL,
                      PHONE = @PHONE
                  WHERE ID = @ID";

            using var connection = _context.CreateConnection();

            return await connection.ExecuteAsync(query, member);
        }

        public async Task<int> DeleteMember(int id)
        {
            var query = "DELETE FROM Members WHERE ID = @ID";

            using var connection = _context.CreateConnection();

            return await connection.ExecuteAsync(query, new { ID = id });
        }
    }
}