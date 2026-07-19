using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetBooks();

        Book? GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);

    }
}