using BlazorCrud.Models;

namespace BlazorCrudApi.Interfaces;

public interface IBookRepository
{
    Task<Book> GetBook(int id);
    Task<List<Book>> GetListBooks();
    Task<Book> CreateBook(Book book);
    Task<Book> UpdateBook(Book book);
    Task<bool> DeleteBook(int id);
}
