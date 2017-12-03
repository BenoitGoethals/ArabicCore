using System;
using System.Collections.Generic;
using ArabicCore.model;

namespace ArabicCore.services
{
    public interface IQuestionService
    {
        IList<Question> Questions();
        IList<Question> Questions(Func<Question, bool> predicate);
        void Delete(Question question);
        Question Add(Question question);
        void Update(Question question);

    }
}