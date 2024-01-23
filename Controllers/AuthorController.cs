using Microsoft.AspNetCore.Mvc;

namespace library.Controllers;

[ApiController]
[Route("authors")]
public class AuthorsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAuthors()
    {
        return Ok("All authors");
    }
}