using System;

namespace HM2ArrayofArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[10][]; //объявление и инициализация массива массивов целых чисел массивом из 10 массивов целых чисел
            Random rnd = new Random(); //объявление переменной rnd
            int i = 0; //объявление и инициализация переменной i
            int j = 0; //объявление и инициализация переменной j
            while (i < array.Length) //цикл пока i меньше длины массива массивов 
            {
                array[i] = new int[rnd.Next()];//заполнение массива i-го элемента случайными числами
                j = 0;//обнуление j
                while (j < array.Length)// цикл пока j меньше длины массива
                {
                    
                    array[i][j] = rnd.Next();//заполнение j-ого элемента i-ого массива 
                    Console.WriteLine(array[i][j]);//вывод на экран массива j-ого элемента i-ого массива
                    j++;//увеличение j на 1
                }
                i++;//увеличение i на 1
            }
        }
    }
}
