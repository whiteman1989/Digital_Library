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
        public DbSet<Questionnarie> Questionnaries { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerVariant> AnswerVariants { get; set; }
        public DbSet<Answer> Answers { get; set; }

        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new ApplicationDbInitializer());
        }

        public ApplicationContext (string connectionString) : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
    }
}
