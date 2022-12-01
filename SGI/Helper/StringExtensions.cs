using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SGI.Helper
{
    public static class StringExtensions
    {
        public static string RemoveMask(this string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            return Regex.Replace(text, @"[^\d]", "");
        }

        public static string GetDisplayName(this Enum val)
        {
            return val.GetType()
                      .GetMember(val.ToString())
                      .FirstOrDefault()
                      ?.GetCustomAttribute<DisplayAttribute>(false)
                      ?.Name
                      ?? val.ToString();
        }
    }
}
