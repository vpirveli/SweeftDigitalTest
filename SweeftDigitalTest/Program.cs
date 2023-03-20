using Azure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Xml;

namespace SweeftDigitalTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string choice;

            do
            {
                await Console.Out.WriteAsync("Choose number from 1 to 8, or choose 0 to exit: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        await Console.Out.WriteLineAsync("GoodBye!"); ;
                        break;
                    case "1":
                        TestOne.Test();
                        break;
                    case "2":
                        TestTwo.Test();
                        break;
                    case "3":
                        TestThree.Test();
                        break;
                    case "4":
                        TestFour.Test();
                        break;
                    case "5":
                        TestFive.Test();
                        break;
                    case "6":
                        Console.WriteLine("You can view SQL querries and Database backup in folder named - \"Test6\"");
                        break;
                    case "7":
                        //Will need SQL connection string change
                        string connectionString = @"Server=WIP;Database=SchoolDB;Trusted_Connection=True; TrustServerCertificate=True";

                        TestSeven.Test(connectionString);
                        break;
                    case "8":
                        //Will need destination path change. Default path C:\Countries\"
                        string folderPath = @"C:\Countries\";

                        await TestEight.Test(folderPath);
                        break;
                    default:
                        await Console.Out.WriteLineAsync("As the grail knight from the acclaimed movie Indiana Jones and the Last Crusade said.");
                        await Console.Out.WriteLineAsync("You chose poorly.");
                        await Console.Out.WriteLineAsync("Try again - Choose from 1-8");
                        break;
                }
            } while (!choice.Equals("0"));
        }
    }
}