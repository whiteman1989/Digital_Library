using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.DAL.Entities;

namespace Digital_Library.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> Posts { get; }
        IRepository<Comment> Comments { get; }

        /// <summary>
        /// Call save methods in each repository
        /// </summary>
        void Save();
    }
}
