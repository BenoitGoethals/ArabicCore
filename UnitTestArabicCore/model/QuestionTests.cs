using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.InteropServices;
using ArabicCore.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using UnitTestArabicCore.Properties;

namespace UnitTestArabicCore.model
{
    [TestClass()]
    public class QuestionTests
    {

        [TestMethod()]
        public void EqualsTest()
        {
            Question question = new Question() { QuestionID = 1, Chapter = "1", ForeignLanguageItem = "hallo", FirstLanguageItem = "dsfds", NativeWriting = "", Picture = null, Status = Status.Reading, WordType = WordType.Adjectif };
            Question question2 = new Question(1, "1", WordType.Adjectif, "jllkj", "lmkm", "mlkm", null, Status.Reading);
            Check.That(question).Equals(question2);


        }

        [TestMethod()]
        public void CompareDutch()
        {
            Question question = new Question() { QuestionID = 1, Chapter = "1", ForeignLanguageItem = "hallo", FirstLanguageItem = "dsfds", NativeWriting = "", Picture = null, Status = Status.Reading, WordType = WordType.Adjectif };

            Check.That(question.FirstLanguageItem).Equals("dsfds");
            Check.That(question.CompareAnswerFirstLanguage("dsfds")).IsTrue();


        }


        [TestMethod()]
        public void CompareArabic()
        {
            Question question = new Question() { QuestionID = 1, Chapter = "1", ForeignLanguageItem = "hallo", FirstLanguageItem = "dsfds", NativeWriting = "", Picture = null, Status = Status.Reading, WordType = WordType.Adjectif };

            Check.That(question.ForeignLanguageItem).Equals("hallo");
            Check.That(question.CompareAnswerForeignLanguage("hallo")).IsTrue();

        }


        [TestMethod()]
        public void CompareDutchFalse()
        {
            Question question = new Question() { QuestionID = 1, Chapter = "1", ForeignLanguageItem = "hallo", FirstLanguageItem = "dsfds", NativeWriting = "", Picture = null, Status = Status.Reading, WordType = WordType.Adjectif };

            Check.That(question.FirstLanguageItem).Equals("dsfds");
            Check.That(question.CompareAnswerFirstLanguage("sds")).IsFalse();


        }


        [TestMethod()]
        public void CompareArabicFalse()
        {
            Question question = new Question() { QuestionID = 1, Chapter = "1", ForeignLanguageItem = "hallo", FirstLanguageItem = "dsfds", NativeWriting = "", Picture = null, Status = Status.Reading, WordType = WordType.Adjectif };

            Check.That(question.ForeignLanguageItem).Equals("hallo");
            Check.That(question.CompareAnswerForeignLanguage("ere")).IsFalse();

        }


        [TestMethod()]
        public void ReadCsv()
        {
            char[] archDelim = new char[] { '\r', '\n' };

            string[] lines = Resources.Woordenboek.Split(archDelim, StringSplitOptions.RemoveEmptyEntries);


            var query = from csvline in lines
                        let data = csvline.Split(';')
                        select new Question()
                        {
                            QuestionID = Convert.ToInt32(data[0]),
                            FirstLanguageItem = data[1],
                            ForeignLanguageItem = data[2],
                            NativeWriting = data[3],
                            WordType = (data[4] == "adjectief" ? WordType.Adjectif :
                                data[4] == "telwoord" ? WordType.CountWord :
                                    data[4] == "uitdrukking" ? WordType.Expression :
                                        data[4] == "persoonlijk voornaamwoord" ? WordType.PersonalForname :
                                            data[4] == "functiewoorden" ? WordType.FunctionWord : WordType.Substantif),//data[3],
                            Chapter = data[5],
                            Status = (data[6] == "" ? Status.Reading : Status.Writing),
                            Picture = Getpicture(Convert.ToInt32(data[0]))
                            

                        };

            Check.That(query.Count()).IsStrictlyGreaterThan(0);
        }



        private byte[] Getpicture(int nr)
        {
           
            string fileName = $"C:\\Users\\Benoit\\source\\repos\\ArabicCore\\UnitTestArabicCore\\Pictures\\Picture{nr}.jpg";
           
            FileInfo fileInfo = new FileInfo(fileName);
            if(!fileInfo.Exists) return new byte[0];
         
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] imageData  = br.ReadBytes((int)imageFileLength);
            return imageData;
        }



        

    }
}