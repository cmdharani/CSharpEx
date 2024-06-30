using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System // if extension methods is in same namespace, it will refer automatically, otherwise we need to import the namespace
                 // so better to use the system namespace
{
    public static class StringExtensions
    {
        public static string Shortened(this string str, int numberOfWords)
        {

            if (str == null) throw new ArgumentNullException(nameof(str));

            if (numberOfWords <= 0)
                throw new ArgumentNullException("string length should be greater than 0 ");

            var parts = str.Split(' ');

            if (parts.Length < numberOfWords)
                return str;

            return string.Join(" ", parts.Take(numberOfWords));

        }
    }
}




namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static bool isPrimeNumber(this int number)
        {
            if(number %2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
