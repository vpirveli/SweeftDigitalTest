using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SweeftDigitalTest
{
    internal class TestEight
    {
        const string urlString = "https://restcountries.com/v3.1/all";

        public static async Task Test(string folderPath)
        {
            await GenerateCountryDataFiles(folderPath);
        }

        public static async Task GenerateCountryDataFiles(string folderPath)
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(urlString);
            bool close = true;
            do
            {
                await Console.Out.WriteAsync("Do you want me to generate .TXT file of the countries? Y/N: ");
                string choise = Console.ReadLine().ToLower();
                if (choise.Equals("y")){
                    JArray countries = JArray.Parse(json);

                    // Filename location will need to be changed or removed

                    Directory.CreateDirectory(folderPath);

                    foreach (JObject country in countries)
                    {
                        string fileName = folderPath + (string)country["name"]["common"] + ".txt";
                        string region = (string)country["region"];
                        string subregion = (string)country["subregion"];
                        JArray latlng = (JArray)country["latlng"];
                        double? area = (double?)country["area"];
                        int? population = (int?)country["population"];

                        // Write the data to the file
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            writer.WriteLine($"Region: {region}");
                            writer.WriteLine($"Subregion: {subregion}");
                            writer.WriteLine($"Latitude: {latlng[0]}, Longitude: {latlng[1]}");
                            writer.WriteLine($"Area: {area} km²");
                            writer.WriteLine($"Population: {population}");
                        }
                    }

                    close = false;

                    await Console.Out.WriteLineAsync("TXT files have been generated!");
                }
                else if (choise.Equals("n")){
                    await Console.Out.WriteLineAsync("TXT files have not been generated!");

                    close = false;
                }
                else
                {
                    await Console.Out.WriteLineAsync("Did you miss the keyboard? Try again.");
                }
            } while (close);
        }
    }
}
