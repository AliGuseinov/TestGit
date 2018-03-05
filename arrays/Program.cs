using System;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];
            int[] v = new int[5] { 1, 3, 5, 7, 9 };

            arr[1] = 5678;
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);

            //arr = new int[5] { 1, 3, 5, 7, 9 };
        }
    }
}
