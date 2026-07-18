using Dapper;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DapperContext _context;

        public BookRepository(DapperContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            using var connection = _context.CreateConnection();

            string sql = "SELECT * FROM Books";

            var books = connection.Query<Book>(sql).ToList();

            return books;
        }
    }
}