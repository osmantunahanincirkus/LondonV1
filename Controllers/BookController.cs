using System.Security.Claims;
using London.Api.Models.Requests;
using London.Api.Services;
using London.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace London.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookRequestModel model)
    {
        var addedBook = await bookService.AddBookAsync(model);

        return Ok(addedBook);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var userId = HttpContext.User.GetPrincipal(ClaimTypes.NameIdentifier);

        var userBooks = await bookService.GetBooksByUserIdAsync(Convert.ToInt32(userId));

        return Ok(userBooks);
    }
    
    [HttpPost("AddBookToUser")]
    public async Task<IActionResult> AddBookToUser([FromBody] BookRequestModel model)
    {
        var addedBook = await bookService.AddBookToUserAsync(model);

        return Ok(addedBook);
    }
}