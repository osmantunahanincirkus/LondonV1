using London.Api.Models.Entities;
using London.Api.Models.Requests;

namespace London.Api.Services.Interfaces;

public interface IBookService
{
    Task<Book> AddBookAsync(BookRequestModel model);
    Task<List<Book>> GetBooksByUserIdAsync(int userId);
}