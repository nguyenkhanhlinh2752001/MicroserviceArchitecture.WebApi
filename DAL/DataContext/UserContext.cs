using Microservices.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}