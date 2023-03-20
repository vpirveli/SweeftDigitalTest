using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigitalTest
{
    internal class TestSeven
    {
        public static void Test(string connectionString)
        {
            using var context = new SchoolContext(connectionString);

            //constuctor also applies existing Migration
            var repository = new SchoolRepository(context);

            //Adds mock data to the database
            repository.SeedMockData();

            //So the console can display Georgian letters.
            Console.OutputEncoding = Encoding.UTF8;

            var teachers = repository.GetAllTeachersByStudent("გიორგი");

            Console.WriteLine("Teachers of გიორგი is/are:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Teacher: {teacher.Name} {teacher.LastName}");
            }
        }
    }
}
