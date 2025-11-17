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
        public List<Author> Authors { get; set; }
        public IList<Book> Book { get; set; }
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task<IActionResult> OnPostUpdateAuthorAsync(int bookId, int? AuthorID)
        {
            // Găsește cartea
            var book = await _context.Book.FindAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            // Actualizează autorul
            book.AuthorID = AuthorID;
            await _context.SaveChangesAsync();

            // Redirecționează înapoi la pagină pentru a reîncărca datele
            return RedirectToPage();
        }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            BookD = new BookData();
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = sortOrder == "author" ? "author_desc" : "author";
            CurrentFilter = searchString;
            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();
            Authors = await _context.Author.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s => s.Author.FirstName.Contains(searchString)
                || s.Author.LastName.Contains(searchString)
                || s.Title.Contains(searchString));
            }

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    BookD.Books = BookD.Books.OrderByDescending(s =>
                    s.Title);
                    break;
                case "author_desc":
                    BookD.Books = BookD.Books.OrderByDescending(s =>
                    s.Author.FullName);
                    break;
                case "author":
                    BookD.Books = BookD.Books.OrderBy(s =>
                    s.Author.FullName);
                    break;
                default:
                    BookD.Books = BookD.Books.OrderBy(s => s.Title);
                    break;
            }
        }   
    }
}