using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zettel_Mara_Lab2.Models;

namespace Zettel_Mara_Lab2.Pages.AuthorsPages;

public class IndexModel : PageModel
{
    private readonly Zettel_Mara_Lab2Context _context;

    public IndexModel(Zettel_Mara_Lab2Context context)
    {
        _context = context;
    }

    public IList<Authors> Authors { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Authors = await _context.Authors.ToListAsync();
    }
}
