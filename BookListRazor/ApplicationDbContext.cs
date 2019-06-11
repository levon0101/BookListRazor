using BookListRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
