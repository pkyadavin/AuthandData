using Auth.Model.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Item> Item { get; set; } = null;
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }
          
    }
}
