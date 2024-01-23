using library.Models;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers;

[ApiController]
[Route("authors")]
public class AuthorsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAuthors()
    {
        var context = new LibraryContext();
        var authors = context.Authors.ToList();

        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAuthor(int id)
    {
        var context = new LibraryContext();
        var author = context.Authors
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
        var context = new LibraryContext();
        context.Authors.Add(author);
        context.SaveChanges();

        return Accepted();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAuthor(int id, Author data)
    {
        var context = new LibraryContext();
        var author = context.Authors
            .Single(a => a.Id == id);

        if (author == null)
        {
            return NotFound();
        }

        author.Name = data.Name;
        context.SaveChanges();

        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAuthor(int id)
    {
        var context = new LibraryContext();
        var author = context.Authors
            .Single(a => a.Id == id);

        if (author == null)
        {
            return NotFound();
        }

        context.Authors.Remove(author);
        context.SaveChanges();

        return Accepted();
    }
}