using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zettel_Mara_Lab2.Models;

namespace Zettel_Mara_Lab2.Pages.BorrowingPages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Zettel_Mara_Lab2Context _context;

        public IndexModel(Zettel_Mara_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                    .Include(b => b.Book)
                        .ThenInclude(b => b.Authors)
                    .Include(b => b.Member).ToListAsync();
            }
        }
    }
}