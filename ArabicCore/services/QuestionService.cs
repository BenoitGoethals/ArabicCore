using System;
using System.Collections.Generic;
using System.Linq;
using ArabicCore.model;
using ArabicCore.repository;

namespace ArabicCore.services
{
    public class QuestionService: IQuestionService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public IList<Question> Questions()
        {
            return _unitOfWork.QuestionRepository.All();
        }

        public IList<Question> Questions(Func<Question, bool> predicate)
        {
            return _unitOfWork.QuestionRepository.All().Where(predicate).ToList();
        }

        public void Delete(Question question)
        {
            _unitOfWork.QuestionRepository.Delete(question);
        }

        public Question Add(Question question)
        {
            return _unitOfWork.QuestionRepository.Add(question);
        }

        public void Update(Question question)
        {
             _unitOfWork.QuestionRepository.Update(question);
        }
    }
}