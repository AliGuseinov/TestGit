using System;

namespace TestFunctions
{
    class Functions
    {
        private static void doSmthPrivate(){
            Console.WriteLine("private code");
        }

        public static int sum(int a, int b)
        {
            doSmthPrivate();
            return a + b;
        }

        public static double sum(double c, double f)
        {
            return c + f;
        }
    }

    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("989");
            Console.WriteLine(Functions.sum(123, 343));
            Console.WriteLine(Functions.sum(176.0, 3.9));
        }
    }
}
