using System.Security.Claims;
using System.Threading.Tasks;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace London.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // POST: API_URL/books
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookRequestModel model)
        {
            var userId = HttpContext.User.GetPrincipal(ClaimTypes.NameIdentifier);
            var username = HttpContext.User.GetPrincipal(ClaimTypes.Name);

            if (model == null || string.IsNullOrEmpty(model.BookName) || string.IsNullOrEmpty(model.AuthorName))
            {
                return BadRequest("BookName and AuthorName are required fields.");
            }

            var addedBook = await _bookService.AddBookAsync(model, userId);

            return Ok(addedBook);
        }

        // GET: API_URL/books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var userId = HttpContext.User.GetPrincipal(ClaimTypes.NameIdentifier);

            var userBooks = await _bookService.GetBooksByUserIdAsync(userId);

            return Ok(userBooks);
        }
    }
}