using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArabicCore.model;
using NFluent;
using UnitTestArabicCore.Properties;

namespace UnitTestArabicCore
{
    public class TestHelper
    {
        public static IEnumerable<Question> ReadCsv()
        {
            char[] archDelim = new char[] {'\r', '\n'};

            string[] lines = Resources.Woordenboek.Split(archDelim, StringSplitOptions.RemoveEmptyEntries);


            var query = from csvline in lines
                let data = csvline.Split(';')
                select new Question()
                {
                    QuestionID = Convert.ToInt32(data[0]),
                    FirstLanguageItem = data[1],
                    ForeignLanguageItem = data[2],
                    NativeWriting = data[3],
                    WordType = (data[4] == "adjectief"
                        ? WordType.Adjectif
                        : data[4] == "telwoord"
                            ? WordType.CountWord
                            : data[4] == "uitdrukking"
                                ? WordType.Expression
                                : data[4] == "persoonlijk voornaamwoord"
                                    ? WordType.PersonalForname
                                    : data[4] == "functiewoorden"
                                        ? WordType.FunctionWord
                                        : WordType.Substantif), //data[3],
                    Chapter = data[5],
                    Status = (data[6] == "" ? Status.Reading : Status.Writing),
                    Picture = Getpicture(Convert.ToInt32(data[0]))
                };

            return query;
        }


        private static byte[] Getpicture(int nr)
        {
            string fileName =
                $"C:\\Users\\Benoit\\source\\repos\\ArabicCore\\UnitTestArabicCore\\Pictures\\Picture{nr}.jpg";

            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists) return new byte[0];

            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] imageData = br.ReadBytes((int) imageFileLength);
            return imageData;
        }
    }
}