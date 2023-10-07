using System.Text.RegularExpressions;

namespace HomeWork
{
    public static class RegexpHelper
    {
        private const string pattern = "[0-9-()]{10}";

        public static string GetFirstMatch(string str)
        {
            return Regex.Match(str, pattern).Value;
        }
    }
}
