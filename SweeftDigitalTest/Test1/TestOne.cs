using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigitalTest
{
    internal class TestOne
    {
        public static void Test()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Welcome to Matrix.\n\nEnter a word to check if it's a palindrome: ");
            string userInput = Console.ReadLine().ToLowerInvariant();
            bool isPalindrome = IsPalindrome(userInput);

            Console.WriteLine($"\nThe statement that the word {userInput} is a palindrome is {isPalindrome}\n");

            static bool IsPalindrome(string text)
            {
                if (string.IsNullOrEmpty(text) || text.Length <= 1)
                {
                    return true;
                }

                if (text[0] != text[text.Length - 1])
                {
                    return false;
                }

                return IsPalindrome(text.Substring(1, text.Length - 2));
            }
        }
    }
}
