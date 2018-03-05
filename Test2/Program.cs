using System;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int n;
                Console.WriteLine("Введите значение n");
                n = int.Parse(Console.ReadLine());
                int[] numbers = new int[n];
                numbers[0] = 0;
                numbers[1] = 1;
                for (int i = 2; i < numbers.Length; i++)
                {
                    numbers[i] = numbers[i - 1] + numbers[i - 2];
                }
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.WriteLine(numbers);
                }


            
        }
    }
}
