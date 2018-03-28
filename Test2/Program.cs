using System;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3, 3];
            Random rnd = new Random();
            int i = 0;
            int j = 0;
            while (i < 3)
            {
                while (j < 3)
                {
                    array[i, j] = rnd.Next();
                    Console.WriteLine(array[i, j]);

                    j++;
                }
                i++;
            }
        }
    }
}
