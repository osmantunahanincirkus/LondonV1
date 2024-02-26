using System.Collections.Generic;
using System.Threading.Tasks;
using London.Api.Models.Entities;
using London.Api.Models.Requests;

namespace London.Api.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(BookRequestModel model, string userId);
        Task<List<Book>> GetBooksByUserIdAsync(string userId);
    }
}