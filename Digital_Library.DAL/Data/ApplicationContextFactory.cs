using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Digital_Library.DAL.Entities;
using System.Data.Entity.Infrastructure;

namespace Digital_Library.DAL.Data
{
    public class ApplicationContextFactory : IDbContextFactory<ApplicationContext>
    {
        public ApplicationContext Create()
        {
            return new ApplicationContext("DefaultConnection");
        }
    }
}
