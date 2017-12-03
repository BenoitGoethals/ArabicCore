using System.Linq;
using ArabicCore.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;



namespace UnitTestArabicCore.model
{
    
    [TestClass()]
    public class ExamQuestionsTests
    {
        [TestMethod()]
        public void PassedQuestionsTest()
        {
            ExamQuestions examQuestions = new ExamQuestions(Language.FirstLanguage);
            foreach (var question in TestHelper.ReadCsv().Take(10))
            {
                examQuestions.AddQuestion(question);
            }
            Check.That(examQuestions.Questions().Count()).IsStrictlyGreaterThan(0);


            foreach (var question in examQuestions.Questions().Take(3))
            {
                examQuestions.CheckQuestion(question.FirstLanguageItem, question);

            }
            Check.That(examQuestions.PassedQuestions()).Equals(3);
            Check.That(examQuestions.NotPassedQuestions()).Equals(7);
           
            Check.That(examQuestions.Passed().Where(c => c.Item1.FirstLanguageItem == c.Item2)).HasSize(3);
        }


        [TestMethod()]
        public void NotPassedQuestionsTest()
        {

            ExamQuestions examQuestions = new ExamQuestions(Language.FirstLanguage);
            foreach (var question in TestHelper.ReadCsv().Take(10))
            {
                examQuestions.AddQuestion(question);
            }
            Check.That(examQuestions.Questions().Count()).IsStrictlyGreaterThan(0);


            foreach (var question in examQuestions.Questions().Take(3))
            {
                examQuestions.CheckQuestion(question.FirstLanguageItem, question);

            }
            Check.That(examQuestions.PassedQuestions()).Equals(3);
            Check.That(examQuestions.NotPassedQuestions()).Equals(7);

            Check.That(examQuestions.Passed().Where(c => c.Item1.FirstLanguageItem != c.Item2)).HasSize(0);
        }


        [TestMethod()]
        public void CheckQuestionTest()
        {
            ExamQuestions examQuestions = new ExamQuestions(Language.FirstLanguage);
            foreach (var question in TestHelper.ReadCsv())
            {
                examQuestions.AddQuestion(question);
            }
            Check.That(examQuestions.Questions().Count()).IsStrictlyGreaterThan(0);

            
            foreach (var question in examQuestions.Questions())
            {
                examQuestions.CheckQuestion(question.FirstLanguageItem ,question);
               
            }
         
            Check.That(examQuestions.Passed()).HasSize(examQuestions.Questions().Count);
            Check.That(examQuestions.Passed().Where(c => c.Item1.FirstLanguageItem == c.Item2)).HasSize(examQuestions.Questions().Count);
           
        }
    

        [TestMethod()]
        public void AddQuestionTest()
        {
            ExamQuestions examQuestions = new ExamQuestions(Language.FirstLanguage);
            foreach (var question in TestHelper.ReadCsv())
            {
                examQuestions.AddQuestion(question);
            }
            Check.That(examQuestions.Questions().Count()).IsStrictlyGreaterThan(0);
        }
    }
}