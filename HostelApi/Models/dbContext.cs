using Microsoft.EntityFrameworkCore;

namespace HostelApi.Models
{
    public class HostelDbContext: DbContext
    {
        public HostelDbContext()
        { }
        public HostelDbContext(DbContextOptions<HostelDbContext> options)
            : base(options)
        { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
    }
}
