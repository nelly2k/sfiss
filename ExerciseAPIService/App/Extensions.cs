using System.Text;

namespace ExerciseAPIService.App
{
    public static class Extensions
    {
        public static StringBuilder AppendIf(this StringBuilder sb, bool condition, string str)
        {
            if (!condition)
            {
                return sb;
            }

            return sb.Append(str);
        }

        public static StringBuilder AppendNotNull(this StringBuilder sb, object conditionObject, string str)
        {
            if (conditionObject == null || conditionObject is string && string.IsNullOrEmpty(conditionObject.ToString()))
            {
                return sb;
            }

            return sb.Append(str);
        }

    }
}