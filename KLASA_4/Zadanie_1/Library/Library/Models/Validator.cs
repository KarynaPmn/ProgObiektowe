using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Models
{
    public static class Validator
    {
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return Regex.IsMatch(name, @"^[A-Z][a-zA-Z]+$");
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w+$");
        }

        public static bool IsCleanText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            return Regex.IsMatch(text, @"^[A-Za-z0-9\s.,!?\-]+$");
        }

        public static bool IsValidPublicationDate(DateTime date)
        {
            return date <= DateTime.Now;
        }

        public static bool IsValidDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _);
        }

        public static bool IsValidGenre(string genre)
        {
            var validGenres = new[] { "criminal", "fantasy", "trillers", "romanse" };
            return validGenres.Contains(genre.ToLower());
        }

        public static bool IsValidDescription(string description)
        {
            return !string.IsNullOrWhiteSpace(description) && description.Length >= 5;
        }
    }
}
