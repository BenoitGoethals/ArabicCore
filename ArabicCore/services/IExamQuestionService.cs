using System;
using System.Collections.Generic;
using ArabicCore.model;

namespace ArabicCore.services
{
    public interface IExamQuestionService
    {
        IList<ExamQuestions> AllExamQuestions();
        IList<ExamQuestions> AllExamQuestions(Func<ExamQuestions, bool> predicate);
        void Delete(ExamQuestions examQuestions);
        ExamQuestions Add(ExamQuestions examQuestions);
        void Update(ExamQuestions examQuestions);
    }
}