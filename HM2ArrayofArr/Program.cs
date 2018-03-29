using System;

namespace HM2ArrayofArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[10][];
            Random rnd = new Random();
            int i = 0;
            int j = 0;
            while (i < array.Length)
            {
                array[i] = new int[10];
                j = 0;
                while (j < array[i].Length)
                {
                    array[i][j] = rnd.Next();
                    Console.WriteLine(array[i][j]);
                    j++;
                }
                i++;
            }
        }
    }
}
