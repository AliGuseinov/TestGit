using System;

namespace HM2
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
                j = 0;
                while (j < 3)
                {
                    array[i, j] = rnd.Next();
                    j++;
                }
                i++;

            }
                i = 0;
                j = 0;
                while (i < 3)
                {
                    j = 0;
                    while (j < 3)
                    {
                    if (i == j) 
                        Console.WriteLine(array[i,j]);
                        j++;
                    }
                    i++;


                //while (i < 3)
                //{
                //    Console.WriteLine(array[i, i]);
                //    i++;
                //}
                //i++;
            }
           
        }
    }
}
