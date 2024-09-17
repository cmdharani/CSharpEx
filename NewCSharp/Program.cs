using System;

namespace NewCSharp
{
    internal class Program
    {
        public static void Main()
        {

            string words = "this is big city";
            Console.WriteLine($"no of words in the sentence '{words}' are {words.GetWordsCount()}" );


            int number = 10;

            Console.WriteLine($"Is Number {number} is Prime: {number.isPrimeNumber()}");


            Console.ReadLine();
        }


        

    }

    public static class StringExtensionHelper
    {
        public static int GetWordsCount(this string str)
        {
            if (!string.IsNullOrEmpty(str))
                return str.Split(' ').Length;
            return 0;
        }
    }

    public static class IntExtensionHelper
    {
        public static bool isPrimeNumber(this int number)
        {
            if (number % 2== 0) return true;
            return false;
        }
    }

}

