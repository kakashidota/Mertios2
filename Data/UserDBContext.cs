using Microsoft.EntityFrameworkCore;
using NiceLIA.Models.Domain;

namespace NiceLIA.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> _Users { get; set; }
    }
}
