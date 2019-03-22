using System;
using System.ComponentModel;

namespace ConverterDetachProblem
{
    [TypeConverter(typeof(StageTypeConverter))]
    public class Stage : IComparable
    {
        public int StageID { get; }
        public string Label { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public Stage(int id)
        {
            StageID = id;
        }

        public static bool operator ==(Stage a, Stage b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return Equals(a.StageID, b.StageID);
        }

        public static bool operator !=(Stage a, Stage b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return false;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return true;

            return !Equals(a.StageID, b.StageID);
        }

        public int CompareTo(object obj)
        {
            var status = obj as Stage;

            return status == null ? 0 : StageID.CompareTo(status.StageID);
        }

        public override bool Equals(object obj)
        {
            var status = obj as Stage;
            return StageID == status?.StageID;
        }

        public override int GetHashCode()
        {
            return StageID.GetHashCode();
        }

        public static explicit operator string(Stage s)
        {
            return s.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}