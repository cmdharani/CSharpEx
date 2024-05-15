using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpEx
{
    public class Program
    {
        static void Main(string[] args)
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


            //Console.WriteLine("\n \n \n");
            //Console.WriteLine("Extension Methods");

            //string postDetails = "This is long post, where we have lot of description";
            //var shortenedPostDetails = postDetails.Shortened(5);

            //Console.WriteLine(shortenedPostDetails);

            //Console.WriteLine("some of the extesnion method under Linq");

            //IEnumerable<int> numbers = new List<int>() { 23,1,44,1,2};
            //var max = numbers.Max();
            //Console.WriteLine("returning the max number from the Int Array "+ max);

            Console.WriteLine("\n \n \n");
            Console.WriteLine("Nullable types ");

            DateTime? dateTime=null;
            Console.WriteLine(""+dateTime.GetValueOrDefault());
            Console.WriteLine("" +dateTime.HasValue);
            Console.WriteLine(""+ dateTime.Value);



            Console.ReadLine();

        }
    }
}
