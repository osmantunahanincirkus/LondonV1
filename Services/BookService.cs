using London.Api.Models;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using Microsoft.EntityFrameworkCore;
using London.Api.Services.Interfaces;

namespace London.Api.Services;

public sealed class BookService(MyDBContext context) : IBookService
{
    public async Task<Book> AddBookAsync(BookRequestModel model)
    {
        var book = new Book
        {
            Name = model.BookName,
            Author = model.AuthorName
        };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return book;
    }

    public async Task<List<Book>> GetBooksByUserIdAsync(int userId)
    {
        var userBooks = await context.Books.Include(x => x.Users)
            .Where(b => b.Users.Any(y => y.Id == userId))
            .ToListAsync();

        return userBooks;
    }
}