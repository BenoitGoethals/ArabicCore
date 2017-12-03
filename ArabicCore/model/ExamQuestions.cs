using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArabicCore.model
{
    public class ExamQuestions
    {
        [Key]
        public int examID { get; set; }

        public Language CheckLanguage { get;  }
        private readonly ISet<Question> _questionsSet = new HashSet<Question>();
        private readonly ISet<Tuple<Question, string>> _passedSet =new HashSet<Tuple<Question, string>>();
       

        public ExamQuestions(Language language)
        {
            this.CheckLanguage = language;
        }

        public void AddQuestion(Question question)
        {
            this._questionsSet.Add(question);
        }

        public ISet<Question> Questions()
        {
            return _questionsSet;
        }

        public ISet<Tuple<Question, string>> Passed()
        {
            return _passedSet;
        }


        public bool CheckQuestion(string answer, Question question)
        {
            if (Language.FirstLanguage == CheckLanguage)
            {

                if (question.CompareAnswerFirstLanguage(answer))
                {
                    this._passedSet.Add(new Tuple<Question, string>(question, answer));
                    return true;
                }
            }
            else
            {
                if (question.CompareAnswerForeignLanguage(answer))
                {
                    this._passedSet.Add(new Tuple<Question, string>(question, answer));
                    return true;
                }
            }
            return false;
        }

        public int PassedQuestions()
        {
            return _passedSet.Count;
        }

        public int NotPassedQuestions()
        {
            return _questionsSet.Count - _passedSet.Count;
        }
    }
}