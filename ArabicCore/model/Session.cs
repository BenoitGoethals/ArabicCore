using System;
using System.ComponentModel.DataAnnotations;

namespace ArabicCore.model
{
    public class Session
    {
        [Key]
        public int sessionID { get; set; }

        public ExamQuestions ExamQuestions { get; set; }

        public DateTime DateTimeExecuted { get; set; }


        
    }
}