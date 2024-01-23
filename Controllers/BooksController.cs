using library.Models;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        var books = _context.Books.ToList();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _context.Books
            .Single(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();

        return Accepted();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book data)
    {
        var book = _context.Books
            .Single(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = data.Title;
        book.Description = data.Description;
        book.Author = data.Author;
        _context.SaveChanges();

        return Accepted();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books
            .Single(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        _context.SaveChanges();

        return Accepted();
    }
}