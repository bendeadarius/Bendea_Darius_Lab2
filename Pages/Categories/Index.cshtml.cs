using Bendea_Darius_Lab2.Data;
using Bendea_Darius_Lab2.Models;
using Bendea_Darius_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bendea_Darius_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Bendea_Darius_Lab2Context _context;

        public IndexModel(Bendea_Darius_Lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            // Încarcă categoriile cu cărțile asociate
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .FirstOrDefault(i => i.ID == id.Value);

                if (category != null)
                {
                    // Extrage cărțile din categoria selectată
                    CategoryData.Books = category.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}