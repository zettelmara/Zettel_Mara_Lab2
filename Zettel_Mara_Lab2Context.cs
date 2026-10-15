using Microsoft.EntityFrameworkCore;

public class Zettel_Mara_Lab2Context(DbContextOptions<Zettel_Mara_Lab2Context> options) : DbContext(options)
{
    public DbSet<Zettel_Mara_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Zettel_Mara_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Zettel_Mara_Lab2.Models.Authors> Authors { get; set; } = default!;
}
