using Microsoft.EntityFrameworkCore;

namespace Music_LibraryBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
