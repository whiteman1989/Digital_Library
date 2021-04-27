using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Digital_Library.DAL.Entities;

namespace Digital_Library.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new ApplicationDbInitializer());
        }

        public ApplicationContext (string connectionString) : base(connectionString)
        {
        }
    }
}
