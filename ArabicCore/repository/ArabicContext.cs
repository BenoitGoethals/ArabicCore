using System.Data.Entity.Infrastructure;
using ArabicCore.model;

namespace ArabicCore.repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ArabicContext : DbContext
    {
        // Your context has been configured to use a 'ArabicContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ArabicCore.repository.ArabicContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ArabicContext' 
        // connection string in the application configuration file.
        public ArabicContext()
            : base("name=ArabicContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<ExamQuestions> ExamQuestionses { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }



       
        
    }

    
}