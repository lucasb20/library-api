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
        Book? book = null;
        try{
            book = _context.Books
                .Single(b => b.Id == id);
        }
        catch(Exception){
            return NotFound(new { message = "Book not found" });
        }

        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook(Book book)
    {
        _context.Books.Add(new Book
        {
            Title = book.Title,
            Description = book.Description,
            Author = book.Author
        });
        _context.SaveChanges();

        return Accepted(new { message = "Book created" });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book data)
    {
        Book? book = null;

        try{
            book = _context.Books
                .Single(b => b.Id == id);
        }
        catch(Exception){
            return NotFound(new { message = "Book not found" });
        }

        book.Title = data.Title;
        book.Description = data.Description;
        book.Author = data.Author;
        _context.SaveChanges();

        return Accepted(new { message = "Book updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        Book? book = null;

        try{
            book = _context.Books
                .Single(b => b.Id == id);
        }
        catch(Exception){
            return NotFound(new { message = "Book not found" });
        }

        _context.Books.Remove(book);
        _context.SaveChanges();

        return Accepted(new { message = "Book deleted" });
    }
}