using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.DAL.Entities;

namespace Digital_Library.DAL.Interfaces
{
    /// <summary>
    /// Interface for imlementing the Unit of Work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Posts repository
        /// </summary>
        IRepository<Post> Posts { get; }
        /// <summary>
        /// Comments repository
        /// </summary>
        IRepository<Comment> Comments { get; }
        /// <summary>
        /// Questions Repository
        /// </summary>
        IRepository<Question> Questions { get; }
        /// <summary>
        /// Questionnaries repository
        /// </summary>
        IRepository<Questionnarie> Qestionnaries { get; }
        /// <summary>
        /// Answers variants repository
        /// </summary>
        IRepository<AnswerVariant> AnswerVariants { get; }
        /// <summary>
        /// Answers repository
        /// </summary>
        IRepository<Answer> Answers { get; }

        /// <summary>
        /// Call save methods in each repository
        /// </summary>
        void Save();
    }
}
