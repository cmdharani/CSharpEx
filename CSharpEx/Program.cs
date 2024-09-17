using System;
using ExtensionMethods;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace CSharpEx
{
    public class Program
    {
        static void Main()
        {
            //Console.WriteLine("today I came to know the CW is the shortcut for console writeline");


            //int a = 1;
            //int b = 2;
            //Console.WriteLine($"Before swapping int a={a} and int b={b}");
            //Generics.Swap<int>(ref a,ref b);
            //Console.WriteLine($"After swapping int a={a} and int b={b}");

            //Console.WriteLine();

            //string firstName = "Madhu";
            //string lastName = "Dharani";

            //Console.WriteLine($"Before swapping string firstName={firstName} and string lastName={lastName}");
            //Generics.Swap<string>(ref firstName, ref lastName);
            //Console.WriteLine($"After swapping string firstName={firstName} and string lastName={lastName}");

            //Console.WriteLine(Generics.isNumberEqual(4,4));
            //Console.WriteLine(Generics.isStringEqual("ax", "ax"));

            //int x = 3;
            //int y = 3;
            //string name = "testing";
            //string name1 = "testing";

            //Console.WriteLine($"checking equal using Generics for Int type -->{x} and {y} " + Generics.IsItEqual(x, y));
            //Console.WriteLine($"checking equal using Generics for string --> {name} and {name1} " + Generics.IsItEqual(name, name1));


            Console.WriteLine("\n \n \n");
            Console.WriteLine("Extension Methods");

            string postDetails = "This is long post, where we have lot of description";
            var shortenedPostDetails = postDetails.Shortened(5);
            Console.WriteLine(shortenedPostDetails);


            int ad = 3;
            var result = ad.isPrimeNumber();

            Console.WriteLine(result);

            //Console.WriteLine(shortenedPostDetails);

            //Console.WriteLine("some of the extesnion method under Linq");

            //IEnumerable<int> numbers = new List<int>() { 23,1,44,1,2};
            //var max = numbers.Max();
            //Console.WriteLine("returning the max number from the Int Array "+ max);

            //Console.WriteLine("\n \n \n");
            //Console.WriteLine("Nullable types ");

            //DateTime? dateTime=null;
            //Console.WriteLine(""+dateTime.GetValueOrDefault());
            //Console.WriteLine("" +dateTime.HasValue);
            //Console.WriteLine(""+ dateTime.Value);




            //Delegates

            Square sq = NumberSquare;
            Console.WriteLine(sq(8));



            ArrayList Numbers1 = new ArrayList(2);
            // Boxing happens - Converting Value type (100, 200) to reference type
            // Means Integer to object type
            Numbers1.Add(100);
            Numbers1.Add(200);
            // Unboxing happens - 100 and 200 stored as object type
            // now converted to Integer type
            foreach (int Number in Numbers1)
            {
                Console.Write(Number + "  ");
            }
        
            Console.WriteLine("JI");

            ArrayList Numbers = new ArrayList(3);
            Numbers.Add(100);
            Numbers.Add(200);
            Numbers.Add(300);
            //It is also possible to store string values
            Numbers.Add("Hi");
            foreach (int Number in Numbers)
            {
                Console.Write(Number + "  ");
            }
            Console.ReadKey();

            Console.ReadLine();

        }



        public delegate int Square(int num);

        static int NumberSquare(int num)
        {
            return num * num;
        }
    }
}










