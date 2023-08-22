using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Db
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }
    }
}
