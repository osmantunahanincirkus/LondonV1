using London.Api.Models;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Models.Responses;
using Microsoft.EntityFrameworkCore;
using London.Api.Services.Interfaces;

namespace London.Api.Services;

public sealed class BookService(MyDBContext context) : IBookService
{
    public async Task<Books> AddBookAsync(BookRequestModel model)
    {
        var book = new Books
        {
            Name = model.BookName,
            Author = model.AuthorName
        };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return book;
    }

    public async Task<List<BookDto>> GetBooksByUserIdAsync(int userId)
    {
        var userBooks = await context.UsersToBooks
            .Where(utb => utb.UserId == userId)
            .Include(utb => utb.Book)
            .Select(utb => new BookDto
            {
                Id = utb.BookId,
                Name = utb.Book.Name,
                Author = utb.Book.Author
            })
            .ToListAsync();
        return userBooks;
    }

    public async Task<Books> AddBookToUserAsync(BookRequestModel model)
    {
        var book = new Books
        {
            Name = model.BookName,
            Author = model.AuthorName
        };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        var usersToBooks = new UsersToBooks
        {
            BookId = book.Id,
            UserId = model.UserId
        };

        context.UsersToBooks.Add(usersToBooks);
        await context.SaveChangesAsync();

        return book;
    }
}