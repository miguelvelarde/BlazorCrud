using BlazorCrudApp.Models;

namespace BlazorCrudApp.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetListBooks();
    Task<Book> GetBook(int id);
    Task<string> CreateBook(Book book);
    Task<bool> UpdateBook(Book book);
    Task<bool> DeleteBook(int id);
}

