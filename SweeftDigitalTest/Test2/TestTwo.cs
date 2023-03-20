using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigitalTest
{
    internal class TestTwo
    {
        public static void Test()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Welcome to Matrix.\n\nEnter your money (in cents): ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            int[] splitMin = MinSplit(userInput);

            Console.WriteLine($"50: {splitMin[0]}\n20: {splitMin[1]}\n10: {splitMin[2]}\n5: {splitMin[3]}\n1: {splitMin[4]}");


            static int[] MinSplit(int userInput)
            {
                int[] coinDenominations = { 50, 20, 10, 5, 1 };
                int[] coinCounts = new int[coinDenominations.Length];

                for (int i = 0; i < coinDenominations.Length; i++)
                {
                    coinCounts[i] = userInput / coinDenominations[i];
                    userInput %= coinDenominations[i];
                }

                return coinCounts;
            }
        }
    }
}
