using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zettel_Mara_Lab2.Models;

namespace Zettel_Mara_Lab2.Pages.PublisherPages;

public class DetailsModel : PageModel
{
    private readonly Zettel_Mara_Lab2Context _context;
    public DetailsModel(Zettel_Mara_Lab2Context context)
    {
        _context = context;
    }

    public Publisher Publisher { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
        if (publisher is null)
        {
            return NotFound();
        }
        else
        {
            Publisher = publisher;
        }

        return Page();
    }
}
