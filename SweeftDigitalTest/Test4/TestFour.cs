using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigitalTest
{
    internal class TestFour
    {
        public static void Test()
        {
            string input;
            bool check;
            do
            {
                Console.Write("Enter a string containing only '(' and ')' characters: ");
                input = Console.ReadLine();

                check = false;
                foreach (var item in input)
                {
                    if (item != '(' && item != ')')
                    {
                        check = true;
                        break;
                    }
                }
            } while (check || string.IsNullOrWhiteSpace(input));

            bool isProperly = IsProperly(input);
            Console.WriteLine("The Statement:");
            Console.WriteLine($"'(' and ')' signs are used correctly - is {isProperly}");
        }

        private static bool IsProperly(string input)
        {
            int count = 0;

            foreach (var item in input)
            {
                if (item == '(')
                {
                    count++;
                }
                else if (item == ')')
                {
                    count--;
                    if (count < 0)
                        return false;
                }
            }
            return count == 0;
        }
    }
}
