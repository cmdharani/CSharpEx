using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEx
{
    public delegate void MyDelegate(string msg); //declaring a delegate

     class ProgramNew
    {
        static void Main1()
        {
            MyDelegate del = ClassA.MethodA;
            del("Hello World");

            del = ClassB.MethodB;
            del("Hello World");

            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del("Hello World");


            List<string> names1 = new List<string>
            {
                "testing",
                "Ordering",
                "Nothing"
            };


            EmpDel emp = delegate (List<string> abc)
            {
                foreach (var item in abc)
                {
                    Console.WriteLine(item);

                } };
            emp(names1);


            Predicate<string> isUpper = IsUpperCase;

            bool result = isUpper("MADHU");

            Console.WriteLine("is UpperCase "+ result);

            Console.ReadLine();
        }


        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }
    }

    

    public class ClassA
    {
       public static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }
    }

    public class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
        }
    }


    public delegate void EmpDel(List<string> names);

    
}
