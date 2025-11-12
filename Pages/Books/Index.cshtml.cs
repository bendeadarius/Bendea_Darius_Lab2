using Bendea_Darius_Lab2.Data;
using Bendea_Darius_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bendea_Darius_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Bendea_Darius_Lab2Context _context;

        public IndexModel(Bendea_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public List<Author> Authors { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Încarcă lista de autori pentru dropdown
            Authors = await _context.Author.ToListAsync();

            // Încarcă cărțile cu publisher și autor incluși
            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();
        }

        // Handler pentru actualizarea autorului
        public async Task<IActionResult> OnPostUpdateAuthorAsync(int bookId, int? AuthorID)
        {
            // Găsește cartea după ID
            var book = await _context.Book.FindAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            // Actualizează autorul
            book.AuthorID = AuthorID;
            await _context.SaveChangesAsync();

            // Redirecționează înapoi la pagină
            return RedirectToPage();
        }
    }
}