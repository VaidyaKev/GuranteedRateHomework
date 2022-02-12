using GuranteedRate.Homework.Model;
using System;

namespace GuranteedRate.Homework.Domain.Extensions
{
    public static class PersonExtension
    {
        private const char Delimiter = ',';

        public static string ToStr(this Person person)
        {
            return $"{person.FirstName}{Delimiter}" +
                $"{person.LastName}{Delimiter}" +
                $"{person.Email}{Delimiter}" +
                $"{person.DateOfBirth.ToString("d")}{Delimiter}" +
                $"{person.FavoriteColor}";
        }

        public static Person ToObj(this string str)
        {
            return ToObj(str, new char[] { Delimiter });
        }

        public static Person ToObj(this string str, char[] delimiters)
        {
            var properties = str.Trim()
                .Replace(" ", string.Empty)
                .Split(delimiters);

            return new Person()
            {
                FirstName = properties[0],
                LastName = properties[1],
                Email = properties[2],
                DateOfBirth = DateTime.Parse(properties[3]),
                FavoriteColor = properties[4]
            };
        }
    }
}
