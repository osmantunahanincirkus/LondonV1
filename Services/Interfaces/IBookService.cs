using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Models.Responses;

namespace London.Api.Services.Interfaces;

public interface IBookService
{
    Task<Books> AddBookAsync(BookRequestModel model);
    Task<List<BookDto>> GetBooksByUserIdAsync(int userId);
    Task<Books> AddBookToUserAsync(BookRequestModel model);
}