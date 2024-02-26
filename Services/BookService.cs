using System.Collections.Generic;
using System.Threading.Tasks;
using London.Api.Models.Entities;
using London.Api.Models.Requests;

namespace London.Api.Services
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(BookRequestModel model, string userId);
        Task<List<Book>> GetBooksByUserIdAsync(string userId);
    }

    public class BookService : IBookService
    {
        private readonly ChallengeDbContext _context;

        public BookService(ChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBookAsync(BookRequestModel model, string userId)
        {
            var book = new Book
            {
                Name = model.BookName,
                Author = model.AuthorName,
                UserId = userId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<List<Book>> GetBooksByUserIdAsync(string userId)
        {
            var userBooks = await _context.Books
                .Where(b => b.UserId == userId)
                .ToListAsync();

            return userBooks;
        }
    }
}
