using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace pp.Models
{
    public class news_context : IdentityDbContext
    {
        public news_context(DbContextOptions<news_context> options)
            : base(options)
        {

        }

        public DbSet<news> News { get; set; }
        public DbSet<categrory> categrories { get; set; }
        public DbSet<contact_us> contact_Us { get; set; }
        public DbSet<Team_members> team_Members { get; set; }



    }

}
