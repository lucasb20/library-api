using library.Models;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetBooks()
    {
        var context = new LibraryContext();
        var books = context.Books.ToList();

        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBook(int id)
    {
        var context = new LibraryContext();
        var book = context.Books
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
        var context = new LibraryContext();
        context.Books.Add(book);
        context.SaveChanges();

        return Accepted();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateBook(int id, Book data)
    {
        var context = new LibraryContext();
        var book = context.Books
            .Single(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = data.Title;
        book.Description = data.Description;
        book.Author = data.Author;
        context.SaveChanges();

        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteBook(int id)
    {
        var context = new LibraryContext();
        var book = context.Books
            .Single(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        context.Books.Remove(book);
        context.SaveChanges();

        return Accepted();
    }
}