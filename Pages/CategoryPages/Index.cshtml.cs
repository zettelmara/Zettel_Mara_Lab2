using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zettel_Mara_Lab2.Models;
using Zettel_Mara_Lab2.ViewModels;

namespace Zettel_Mara_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Zettel_Mara_Lab2Context _context;

    public IndexModel(Zettel_Mara_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public CategoryIndexData CategoryData { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        CategoryData = new CategoryIndexData();
        CategoryData.Categories = await _context.Category
            .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Authors)
            .OrderBy(c => c.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;
            Category category = CategoryData.Categories
                .Where(c => c.ID == id.Value).Single();
            CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
        }
    }
}
