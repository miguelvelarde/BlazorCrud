using BlazorCrud.Models;
using BlazorCrudApi.Interfaces;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetListBooks()
    {
        List<Book> books = await _context.Books.ToListAsync();
        return books;
    }

    public async Task<Book> GetBook(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> CreateBook(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateBook(Book book)
    {
        var existingBook = await _context.Books.FindAsync(book.Id);
        if (existingBook == null) return new Book();

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Pages = book.Pages;
        existingBook.Price = book.Price;
        existingBook.Description = book.Description;

        await _context.SaveChangesAsync();
        return existingBook;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return false;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
}
