using Microsoft.AspNetCore.Mvc;

namespace library.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok("All books");
    }
}