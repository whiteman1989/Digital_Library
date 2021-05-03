using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Digital_Library.DAL.Entities;
using System.Data.Entity.Infrastructure;

namespace Digital_Library.DAL.Data
{
    /// <summary>
    /// Context Factory
    /// </summary>
    public class ApplicationContextFactory : IDbContextFactory<ApplicationContext>
    {
        /// <summary>
        /// Create context with defoult connection string
        /// </summary>
        /// <returns></returns>
        public ApplicationContext Create()
        {
            return new ApplicationContext("DefaultConnection");
        }
    }
}
