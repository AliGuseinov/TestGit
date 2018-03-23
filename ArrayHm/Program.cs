using System;

namespace ArrayHm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            Random rnd = new Random();

            int i = 0;
            int j = 0;
            while (i < 10)
            {
                i++;

                while (j < 10)
                {
                    j++;


                    array[i, j] = rnd.Next(100);
                    while (array[i, j] > 40)
                    {
                        Console.WriteLine(array[i, j]);

                    }
                }

            }
        }
    }
}
