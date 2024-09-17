using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEx.Patterns
{
    public sealed class Singleton
    {
        private static  Singleton Instance = null;
        private static int Counter = 0;

        //To use the lock, we need to create one variable
        private static readonly object Instancelock = new object();

        public static Singleton GetSingleton()
        {

            lock(Instancelock)
            {
                if (Instance == null)
                {
                    Instance = new Singleton();
                }
            }
            

            return Instance;    
        }

        private Singleton()
        {
            Counter++;
            Console.WriteLine("Counter Value " + Counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }


    }

    public  class MyClass {

        public static void Main1()
        {
            Console.WriteLine("Hi");


            #region SingleTonClass related
            Singleton abc = Singleton.GetSingleton();
            abc.PrintDetails("Madhu here");

            Singleton xyz = Singleton.GetSingleton();
            xyz.PrintDetails("Dharani here");

            Parallel.Invoke(
                //Let us Assume PrintTeacherDetails method is Invoked by Thread-1
                () => PrintTeacherDetails(),
                //Let us Assume PrintStudentDetails method is Invoked by Thread-2
                () => PrintStudentDetails()
                ); 
            #endregion

            Console.WriteLine("---------------------------------------");

            GetSingleInstance objectOne=GetSingleInstance.GetSingleInstanceMethod();
            objectOne.GetSomeMessage("nothing here");

            GetSingleInstance objectTwo = GetSingleInstance.GetSingleInstanceMethod();
            objectTwo.GetSomeMessage("nothing here two");





            Console.ReadLine();
        }

        private static void PrintTeacherDetails()
        {
            //Thread-1 Calling the GetInstance() Method of the Singleton class
            Singleton fromTeacher = Singleton.GetSingleton();
            fromTeacher.PrintDetails("From Teacher");
        }
        private static void PrintStudentDetails()
        {
            //At the same time, Thread-2 also Calling the GetInstance() Method of the Singleton Class
            Singleton fromStudent = Singleton.GetSingleton();
            fromStudent.PrintDetails("From Student");
        }

    }


    public sealed class GetSingleInstance {


        public static  GetSingleInstance instance = null;
        public static int counter = 0;

        //To use the lock, we need to create one variable
        private static readonly object Instancelock = new object();

        private GetSingleInstance()
        {
            counter++;
            Console.WriteLine($"no of object instance : {counter}");
            
        }

        public static GetSingleInstance GetSingleInstanceMethod()
        {
            lock(Instancelock)
            {
                if (instance == null)
                {
                    instance = new GetSingleInstance();
                }
            }

            return instance;
        }

        public void GetSomeMessage(string input)
        {
            Console.WriteLine(input);
        }

    }

}
