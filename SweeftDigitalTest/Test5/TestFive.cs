using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigitalTest
{
    internal class TestFive
    {
        public static void Test()
        {
            int stairs;
            do
            {
                Console.Write("Enter the number of stairs: ");
                stairs = Convert.ToInt32(Console.ReadLine());
            } while (stairs <= 0);

            int countVariants = CountVariants(stairs);

            Console.WriteLine($"There are {countVariants} variants for climbing {stairs} stairs.");
        }

        private static int CountVariants(int stairs)
        {
            if (stairs == 0 || stairs == 1)
                return 1;

            int[] variants = new int[stairs + 1];
            variants[0] = 1;
            variants[1] = 1;

            for (int i = 2; i <= stairs; i++)
            {
                variants[i] = variants[i - 1] + variants[i - 2];
            }

            return variants[stairs];
        }
    }
}
