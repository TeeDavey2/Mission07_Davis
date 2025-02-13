using Microsoft.EntityFrameworkCore;

namespace Mission06_Davis.Models
{
    public class FilmCollectionContext : DbContext
    {
        public FilmCollectionContext(DbContextOptions<FilmCollectionContext> options) : base (options) { } //Constructor

        public DbSet<Application> Applications { get; set; }
    }

}
