using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _dbContext.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return RedirectToPage();

            var bookFromDb = await _dbContext.Books.FindAsync(Book.Id);

            bookFromDb.Name = Book.Name;
            bookFromDb.ISBN = Book.ISBN;
            bookFromDb.Author = Book.Author;

            await _dbContext.SaveChangesAsync();

            Message = "Book has been updated successfully:";

            return RedirectToPage("Index");
        }
    }
}