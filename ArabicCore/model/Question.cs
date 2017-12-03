using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabicCore.model
{
    [Table("Question")]
    public class Question
    {
        public Question()
        {
        }

        public Question(int questionId, string chapter,  WordType wordType, string firstLanguageItem, string foreignLanguageItem, string nativeWriting, byte[] picture, Status status)
        {
            QuestionID = questionId;
            Chapter = chapter;
          
            WordType = wordType;
            FirstLanguageItem = firstLanguageItem;
            ForeignLanguageItem = foreignLanguageItem;
            NativeWriting = nativeWriting;
            Picture = picture;
            Status = status;
        }
        [Key]
        public int QuestionID { get; set; }

        public string Chapter { get; set; }
        [MaxLength(150)]
        [Required]
        public WordType WordType { get; set; }
        [MaxLength(150)]
        [Required]
        public string FirstLanguageItem { get; set; }
        [MaxLength(150)]
        [Required]
        public string ForeignLanguageItem { get; set; }
        [MaxLength(150)]
        public string NativeWriting { get; set; }
        public Byte[] Picture { get; set; }
        public Status Status { get; set; }





        protected bool Equals(Question other)
        {
            return QuestionID == other.QuestionID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Question) obj);
        }

        public override int GetHashCode()
        {
            return QuestionID;
        }

        public static bool operator ==(Question left, Question right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Question left, Question right)
        {
            return !Equals(left, right);
        }


        public bool CompareAnswerFirstLanguage(string first)
        {
            return first.Equals(FirstLanguageItem);
        }

        public bool CompareAnswerForeignLanguage(string foreign)
        {
            return ForeignLanguageItem.Equals(foreign);
        }

        public override string ToString()
        {
            return $"{nameof(QuestionID)}: {QuestionID}, {nameof(Chapter)}: {Chapter},  {nameof(WordType)}: {WordType}, {nameof(FirstLanguageItem)}: {FirstLanguageItem}, {nameof(ForeignLanguageItem)}: {ForeignLanguageItem}, {nameof(NativeWriting)}: {NativeWriting}, {nameof(Picture)}: {Picture}, {nameof(Status)}: {Status}";
        }
    }
}