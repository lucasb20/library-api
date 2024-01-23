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
        Author? author = null;
        try{
            author = _context.Authors
                .Single(a => a.Id == id);
        }
        catch(Exception){
            return NotFound(new { message = "Author not found" });
        }
        
        return Ok(author);
    }

    [HttpPost]
    public IActionResult CreateAuthor(Author author)
    {
        _context.Authors.Add(new Author
        {
            Name = author.Name
        });
        _context.SaveChanges();

        return Accepted(new { message = "Author created" });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, Author data)
    {
        Author? author = null;

        try{
            author = _context.Authors
                .Single(a => a.Id == id);
        }
        catch(Exception){
            return NotFound(new { message = "Author not found" });
        }

        author.Name = data.Name;
        _context.SaveChanges();

        return Accepted(new { message = "Author updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        Author? author = null;

        try{
            author = _context.Authors
                .Single(a => a.Id == id);
        }
        catch(Exception){
            return NotFound(new { message = "Author not found" });
        }

        _context.Authors.Remove(author);
        _context.SaveChanges();

        return Accepted(new { message = "Author deleted" });
    }
}