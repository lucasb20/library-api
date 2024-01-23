using library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var books = _context.Books
            .Include(b => b.Author)
            .ToList();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        Book? book = null;
        try{
            book = _context.Books
                .Include(b => b.Author)
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
        Author? author = null;
        try{
            if(book.Author != null){
                author = _context.Authors.Single(a => a.Id == book.Author.Id);
            }
            else{
                throw new Exception();
            }
        }
        catch(Exception){
            return NotFound(new { message = "Author not found" });
        }

        _context.Books.Add(new Book
        {
            Title = book.Title,
            Description = book.Description,
            Author = author
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