using BlazorCrud.Models;
using BlazorCrudApi.Interfaces;

namespace BlazorCrudApi.DbContext;

public static class BooksEndpoints
{
    private const string URL_BASE = "/api/books";

    public static void MapBookRoutes(this WebApplication app)
    {
        app.MapGet(URL_BASE, async (IBookRepository bookService) =>
            await bookService.GetListBooks());

        app.MapGet($"{URL_BASE}/{{id:int}}", async (int id, IBookRepository bookService) =>
        {
            var post = await bookService.GetBook(id);
            return post is null ? Results.NotFound(new Book()) : Results.Ok(post);
        });

        app.MapPost(URL_BASE, async (Book newBook, IBookRepository bookService) =>
        {
            var newRecord = await bookService.CreateBook(newBook);
            return Results.Created($"{URL_BASE}/{newRecord.Id}", newRecord);
        });

        app.MapPut(URL_BASE, async (Book newBook, IBookRepository bookService) =>
        {
            var newRecord = await bookService.UpdateBook(newBook);
            return Results.Created($"{URL_BASE}/{newRecord.Id}", newRecord);
        });

        app.MapDelete($"{URL_BASE}/{{id:int}}", async (int id, IBookRepository bookService) =>
        {
            return await bookService.DeleteBook(id) ? Results.NoContent() : Results.NotFound();
        });
    }
}
