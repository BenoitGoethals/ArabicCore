using System;
using System.Collections.Generic;
using System.Linq;
using ArabicCore.model;
using ArabicCore.repository;

namespace ArabicCore.services
{
    public class ExamQuestionService: IExamQuestionService
    {

        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        

        public IList<ExamQuestions> AllExamQuestions()
        {
            return _unitOfWork.ExamQuestionsRepository.All();
        }

        public IList<ExamQuestions> AllExamQuestions(Func<ExamQuestions, bool> predicate)
        {
           return  _unitOfWork.ExamQuestionsRepository.All(predicate);
        }

        public void Delete(ExamQuestions examQuestions)
        {
             _unitOfWork.ExamQuestionsRepository.Delete(examQuestions);
        }

        public ExamQuestions Add(ExamQuestions examQuestions)
        {
            return  _unitOfWork.ExamQuestionsRepository.Add(examQuestions);
        }

        public void Update(ExamQuestions examQuestions)
        {
             _unitOfWork.ExamQuestionsRepository.Update(examQuestions);
        }
    }
}