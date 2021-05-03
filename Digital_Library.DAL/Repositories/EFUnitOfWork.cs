using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.DAL.Interfaces;
using Digital_Library.DAL.Entities;
using Digital_Library.DAL.Data;

namespace Digital_Library.DAL.Repositories
{
    /// <summary>
    /// Implements IUnitOfWork interface for using with Entity Framework
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;
        private PostsRepository postsRepository;
        private CommentsRepository commentsRepository;
        private QuestionnariesRepository questionnariesRepository;
        private QuestionsRepository questionsRepository;
        private AnswerVariantsRepository answerVariantsRepository;
        private AnswersRepository answersRepository;

        /// <summary>
        /// Constructor that use ApplicationContextFactory for create db context with defoult connection string
        /// </summary>
        public EFUnitOfWork()
        {
            db = new ApplicationContextFactory().Create();
        }


        /// <summary>
        /// Constructor that create db context with costum connection string
        /// </summary>
        /// <param name="connectionString">conntection string</param>
        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
        }

        public IRepository<Post> Posts
        {
            get
            {
                if (postsRepository is null) postsRepository = new PostsRepository(db);
                return postsRepository;
            }
        }
        public IRepository<Comment> Comments
        { 
            get
            {
                if (commentsRepository is null) commentsRepository = new CommentsRepository(db);
                return commentsRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questionsRepository is null) questionsRepository = new QuestionsRepository(db);
                return questionsRepository;
            }
        }

        public IRepository<Questionnarie> Qestionnaries 
        {
            get
            {
                if (questionnariesRepository is null) questionnariesRepository = new QuestionnariesRepository(db);
                return questionnariesRepository;
            }
        }

        public IRepository<AnswerVariant> AnswerVariants
        {
            get
            {
                if (answerVariantsRepository is null) answerVariantsRepository = new AnswerVariantsRepository(db);
                return answerVariantsRepository;
            }
        }

        public IRepository<Answer> Answers
        {
            get
            {
                if (answersRepository is null) answersRepository = new AnswersRepository(db);
                return answersRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Save all change in db context
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
