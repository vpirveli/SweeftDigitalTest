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
            if (stairs == 0)
                return 1;
            else if (stairs < 0)
                return 0;

            return CountVariants(stairs - 1) + CountVariants(stairs - 2);
        }
    }
}
