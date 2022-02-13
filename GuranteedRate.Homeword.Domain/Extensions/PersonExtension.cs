using GuranteedRate.Homework.Model;
using System;

namespace GuranteedRate.Homework.Domain.Extensions
{
    public static class PersonExtension
    {
        private const char Delimiter = ',';

        public static string ToStr(this Person person)
        {
            return $"{person.LastName}{Delimiter}" + 
                $"{person.FirstName}{Delimiter}" +
                $"{person.Email}{Delimiter}" +
                $"{person.FavoriteColor}{Delimiter}" +
                $"{person.DateOfBirth.ToString("d")}";
        }

        public static Person ToObj(this string str)
        {
            if (!str.Contains(","))
            {
                throw new ArgumentException("Must be Comma Seperated Value");
            }

            return ToObj(str, new char[] { Delimiter });
        }

        public static Person ToObj(this string str, char[] delimiters)
        {
            if(delimiters == null || delimiters.Length == 0)
            {
                throw new ArgumentException("Must Have at Least One Delimeters", "delimeters");
            }

            var properties = str.Trim()
                .Split(delimiters);

            return new Person()
            {
                LastName = properties[0].Replace(" ", string.Empty),
                FirstName = properties[1].Replace(" ", string.Empty),
                Email = properties[2].Replace(" ", string.Empty),
                FavoriteColor = properties[3].Replace(" ", string.Empty),
                DateOfBirth = DateTime.Parse(properties[4].Replace(" ", string.Empty)),
            };
        }
    }
}
