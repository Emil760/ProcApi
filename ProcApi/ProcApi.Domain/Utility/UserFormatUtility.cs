namespace ProcApi.Domain.Utility
{
    public class UserFormatUtility
    {
        public static string FormatUser(string firstName, string secondName, string fatherName, string format)
        {
            var result = format;

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                var firstNameChar1 = firstName[0];
                result = result.Replace('F', firstNameChar1);
            }

            if (!string.IsNullOrWhiteSpace(secondName))
            {
                var secondNameChar1 = secondName[0];
                result = result.Replace('S', secondNameChar1);
            }

            if (!string.IsNullOrWhiteSpace(fatherName))
            {
                var fatherNameChar1 = fatherName[0];
                result = result.Replace('O', fatherNameChar1);
            }

            return result;
        }
    }
}
