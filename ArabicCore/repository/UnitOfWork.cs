using System;
using System.Threading.Tasks;
using ArabicCore.model;

namespace ArabicCore.repository
{
  
        public class UnitOfWork : IUnitOfWork, IDisposable
        {
            //Our database context 
            private readonly ArabicContext _dbContext = new ArabicContext();

            //Private members corresponding to each concrete repository
            private Repository<Question> _questionRepository;
            private Repository<ExamQuestions> _examQuestionsRepository;
            private Repository<Session> _sessionsRepository;

        //Accessors for each private repository, creates repository if null
        public IRepository<Question> QuestionRepository
        {
                get
                {
                    if (_questionRepository == null)
                    {
                        _questionRepository = new Repository<Question>(_dbContext);
                }
                    return _questionRepository;
                }

            }

            public IRepository<Session> SessionsRepository
        {
                get
                {
                    if (_sessionsRepository == null)
                    {
                        _sessionsRepository = new Repository<Session>(_dbContext);
                    }
                    return _sessionsRepository;
                }

            }

        public IRepository<ExamQuestions> ExamQuestionsRepository
        {
                get
                {
                    if (_examQuestionsRepository == null)
                    {
                        _examQuestionsRepository = new Repository<ExamQuestions>(_dbContext);
                    }
                    return _examQuestionsRepository;
                }

            }

            //Method to save all changes to repositories
            public void Commit()
            {
                _dbContext.SaveChanges();
            }

            public async Task CommitAsync()
            {
                await _dbContext.SaveChangesAsync();
             }

            //IDisposible implementation
            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        _dbContext.Dispose();
                    }
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

    }