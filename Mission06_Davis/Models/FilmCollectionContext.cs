using Microsoft.EntityFrameworkCore;

namespace Mission06_Davis.Models
{
    public class FilmCollectionContext : DbContext
    {
        public FilmCollectionContext(DbContextOptions<FilmCollectionContext> options) : base (options) { } //Constructor

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CategoryModel>.HasData(
        //        new CategoryModel { CategoryId }
        //        );
        //}
    }

}
