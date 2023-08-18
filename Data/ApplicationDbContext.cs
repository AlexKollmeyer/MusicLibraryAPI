using Microsoft.EntityFrameworkCore;
using Music_LibraryBackend.Models;

namespace Music_LibraryBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
