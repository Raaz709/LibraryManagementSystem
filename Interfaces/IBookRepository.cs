using LibraryManagementSystem.Model;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
    }
}