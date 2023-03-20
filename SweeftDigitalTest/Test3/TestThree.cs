using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigitalTest 
    { 
    internal class TestThree
    {
        #region Constants
        private const int TextTimer = 100; // change to 0 to be faster
        private const int CalculateTimer = 3000; // change to 0 to be faster
        #endregion

        public static void Test()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            AnimatedText("Welcome to Matrix.\nMatrix will now generate the array of random numbers...\n");
            Thread.Sleep(CalculateTimer);

            Random r = new Random();
            int[] rArray = new int[r.Next(10, 30)];

            for (int i = 0; i < rArray.Length; i++)
            {
                Thread.Sleep(TextTimer);
                rArray[i] = r.Next(1, 30);
                Console.Write(rArray[i] + " ");
            }

            int notContains = LowestNotContained(rArray);

            AnimatedText("\nCalculating the lowest number not contained in the array.");
            Thread.Sleep(CalculateTimer);
            AnimatedText("\nLowest number not contained: ");
            Thread.Sleep(CalculateTimer);

            Console.WriteLine(notContains);
        }

        private static void AnimatedText(string message)
        {
            foreach (char item in message)
            {
                Thread.Sleep(TextTimer);
                Console.Write(item);
            }
        }

        private static int LowestNotContained(int[] rArray)
        {
            int check = 1;
            while (Array.Exists(rArray, number => number == check))
            {
                check++;
            }
            return check;
        }
    }
}
