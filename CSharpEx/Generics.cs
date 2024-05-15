namespace CSharpEx
{
    public class Generics
    {

        public static void Swap<T>(ref T a, ref T b) 
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        
        }

        public static bool isNumberEqual(int a, int b)
        {
            return (a==b)?true:false;
        }

        public static bool isStringEqual(string a, string b)
        {
            return (a == b) ? true : false;
        }

        public static bool  IsItEqual<T>(T a, T b)
        {
            return a.Equals(b);
        }




    }
}
