namespace ArabicCore.model
{
   
    public class Question
    {
        public Question()
        {
        }

        public Question(int id, string chapter, string rewrite, WordType wordType, string dutch, string arabic, string nativeWriting, byte[] picture, Status status)
        {
            Id = id;
            Chapter = chapter;
            Rewrite = rewrite;
            WordType = wordType;
            Dutch = dutch;
            Arabic = arabic;
            NativeWriting = nativeWriting;
            Picture = picture;
            Status = status;
        }

        public int Id { get; set; }
        public string Chapter { get; set; }
        public string Rewrite { get; set; }
        public WordType WordType { get; set; }
        public string Dutch { get; set; }
        public string Arabic { get; set; }
        public string NativeWriting { get; set; }
        public byte[] Picture { get; set; }
        public Status Status { get; set; }





        protected bool Equals(Question other)
        {
            return Id == other.Id;
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
            return Id;
        }

        public static bool operator ==(Question left, Question right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Question left, Question right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Chapter)}: {Chapter}, {nameof(Rewrite)}: {Rewrite}, {nameof(WordType)}: {WordType}, {nameof(Dutch)}: {Dutch}, {nameof(Arabic)}: {Arabic}, {nameof(NativeWriting)}: {NativeWriting}, {nameof(Picture)}: {Picture}, {nameof(Status)}: {Status}";
        }
    }
}