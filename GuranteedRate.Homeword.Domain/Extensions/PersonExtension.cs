using GuranteedRate.Homework.Model;
using System;
using System.Linq;

namespace GuranteedRate.Homework.Domain.Extensions
{
    public static class PersonExtension
    {
        private const char DefaultDelimiter = ',';
        private static char[] Delimiters = new char[] {'|', DefaultDelimiter };

        public static string ToStr(this Person person)
        {
            return $"{person.LastName}{DefaultDelimiter}" + 
                $"{person.FirstName}{DefaultDelimiter}" +
                $"{person.Email}{DefaultDelimiter}" +
                $"{person.FavoriteColor}{DefaultDelimiter}" +
                $"{person.DateOfBirth.ToString("d")}";
        }

        public static Person ToObj(this string str)
        {
            if (str.IndexOfAny(Delimiters) == -1)
            {
                str = str.Replace(' ', DefaultDelimiter);
            }

            if (str.IndexOfAny(Delimiters) == -1)
            {
                throw new ArgumentException($"Must Contain at Least One Delimeters");
            }

            var properties = str.Trim()
                .Replace(" ", string.Empty)
                .Split(Delimiters);

            return new Person()
            {
                LastName = properties[0],
                FirstName = properties[1],
                Email = properties[2],
                FavoriteColor = properties[3],
                DateOfBirth = DateTime.Parse(properties[4]),
            };
        }
    }
}
