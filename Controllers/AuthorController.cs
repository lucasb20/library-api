using library.Models;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers;

[ApiController]
[Route("authors")]
public class AuthorsController : ControllerBase
{
    private readonly LibraryContext _context;

    public AuthorsController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        var authors = _context.Authors.ToList();

        return Ok(authors);
    }

    [HttpGet("{id}")]
    public IActionResult GetAuthor(int id)
    {
        var author = _context.Authors
            .Single(a => a.Id == id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpPost]
    public IActionResult CreateAuthor(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();

        return Accepted();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, Author data)
    {
        var author = _context.Authors
            .Single(a => a.Id == id);

        if (author == null)
        {
            return NotFound();
        }

        author.Name = data.Name;
        _context.SaveChanges();

        return Accepted();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        var author = _context.Authors
            .Single(a => a.Id == id);

        if (author == null)
        {
            return NotFound();
        }

        _context.Authors.Remove(author);
        _context.SaveChanges();

        return Accepted();
    }
}