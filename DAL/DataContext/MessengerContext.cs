using Microservices.Models.Entities.Messengers;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class MessengerContext : DbContext
    {
        public MessengerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Pool> Pools { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}