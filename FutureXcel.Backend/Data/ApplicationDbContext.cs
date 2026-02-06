using Microsoft.EntityFrameworkCore;

namespace FutureXcel.Backend.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
    {
        
    }
}
