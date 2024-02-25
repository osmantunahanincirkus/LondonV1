using System.Security.Claims;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace London.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BookController : ControllerBase
{
    // POST: API_URL/books
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookRequestModel model)
    {
        // var currentUser = HttpContext.User;
        // var name = currentUser.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

        var userId = HttpContext.User.GetPrincipal(ClaimTypes.NameIdentifier);
        var username = HttpContext.User.GetPrincipal(ClaimTypes.Name);

        // Gelen modelin doğruluğunu kontrol et
        if (model == null || string.IsNullOrEmpty(model.BookName) || string.IsNullOrEmpty(model.AuthorName))
        {
            return BadRequest("BookName and AuthorName are required fields.");
        }

        // Kullanıcıya ait bir kitap ekleyin
        var book = new Book
        {
            Name = model.BookName,
            Author = model.AuthorName,
            User = model.UserId
        };

        // userId

        // _context.Books.Add(book);
        // await _context.SaveChangesAsync();

        return Ok(book); // Eklenen kitabı yanıt olarak döndür
    }

    // GET: API_URL/books
    [HttpGet]
    public async Task<IActionResult> GetBooks(int userId)
    {
        // UserId'ye göre kullanıcının okuduğu kitapları listele
        // var userBooks = await _context.Books.ToListAsync();

        return Ok(HttpContext.User);
    }
}