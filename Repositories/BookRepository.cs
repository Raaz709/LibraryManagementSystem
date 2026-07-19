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

        public Book? GetBookById(int id)
        {
            using var connection = _context.CreateConnection();

            string sql = "SELECT * FROM Books WHERE Id = @Id";

            var book = connection.QueryFirstOrDefault<Book>(sql, new { Id = id });

            return book;
        }

        public void AddBook(Book book)
        {
            using var connection = _context.CreateConnection();

            string sql = @"INSERT INTO Books
                   (Title, Author, Category, Quantity)
                   VALUES
                   (@Title, @Author, @Category, @Quantity)";

            connection.Execute(sql, book);

        }

        public void UpdateBook(Book book)
        {
            using var connection = _context.CreateConnection();

            string sql = @"UPDATE Books
                   SET Title = @Title,
                       Author = @Author,
                       Category = @Category,
                       Quantity = @Quantity
                   WHERE Id = @Id";

            connection.Execute(sql, book);
        }

        public void DeleteBook(int id)
        {
            using var connection = _context.CreateConnection();

            string sql = "DELETE FROM Books WHERE Id = @Id";

            connection.Execute(sql, new { Id = id });
        }

    }
}