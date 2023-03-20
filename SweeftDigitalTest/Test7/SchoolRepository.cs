using Microsoft.EntityFrameworkCore;

namespace SweeftDigitalTest
{
    internal class SchoolRepository
    {
        private readonly SchoolContext _context;

        public SchoolRepository(SchoolContext context)
        {
            _context = context;

            _context.Database.Migrate();
        }

        public void SeedMockData()
        {
            // Teachers
            var teacher1 = new Teacher { Name = "რიმა", LastName = "ლომჯარია", Gender = true, Subject = "გერმანული" };
            var teacher2 = new Teacher { Name = "ციალა", LastName = "ფხაკაძე", Gender = false, Subject = "მათემატიკა" };
            var teacher3 = new Teacher { Name = "ნინო", LastName = "კვარაცხელი", Gender = true, Subject = "მათემატიკა" };
            var teacher4 = new Teacher { Name = "ლევანი", LastName = "ბერიძე", Gender = false, Subject = "ისტორია" };
            var teacher5 = new Teacher { Name = "მარიამი", LastName = "ჭარტიშვილი", Gender = true, Subject = "ქართული" };

            // Pupils
            var pupil1 = new Pupil { Name = "გიორგი", LastName = "კახიძე", Gender = true, Grade = 5 };
            var pupil2 = new Pupil { Name = "ზურა", LastName = "ჯაფარიძე", Gender = false, Grade = 4 };
            var pupil3 = new Pupil { Name = "ხვიჩა", LastName = "მაღლაკელი", Gender = false, Grade = 9 };
            var pupil4 = new Pupil { Name = "ნინი", LastName = "მიქაუტელი", Gender = true, Grade = 10 };
            var pupil5 = new Pupil { Name = "დავითი", LastName = "კახიძე", Gender = false, Grade = 11 };

            _context.Teacher.AddRange(new List<Teacher> { teacher1, teacher2, teacher3, teacher4, teacher5 });
            _context.Pupil.AddRange(new List<Pupil> { pupil1, pupil2, pupil3, pupil4, pupil5 });
            _context.SaveChanges();

            // TeacherPupil
            var teacherPupil1 = new TeacherPupil { TeacherId = teacher1.Id, PupilId = pupil1.Id };
            var teacherPupil2 = new TeacherPupil { TeacherId = teacher1.Id, PupilId = pupil2.Id };
            var teacherPupil3 = new TeacherPupil { TeacherId = teacher2.Id, PupilId = pupil1.Id };
            var teacherPupil4 = new TeacherPupil { TeacherId = teacher3.Id, PupilId = pupil3.Id };
            var teacherPupil5 = new TeacherPupil { TeacherId = teacher3.Id, PupilId = pupil4.Id };
            var teacherPupil6 = new TeacherPupil { TeacherId = teacher4.Id, PupilId = pupil3.Id };
            var teacherPupil7 = new TeacherPupil { TeacherId = teacher5.Id, PupilId = pupil3.Id };
            var teacherPupil8 = new TeacherPupil { TeacherId = teacher5.Id, PupilId = pupil5.Id };

            _context.TeacherPupil.AddRange(teacherPupil1, teacherPupil2, teacherPupil3, teacherPupil4, teacherPupil5, teacherPupil6, teacherPupil7, teacherPupil8);

            _context.SaveChanges();
        }

        public Teacher[] GetAllTeachersByStudent(string studentName)
        {
            var teachers = _context.TeacherPupil
                .Include(tp => tp.Teacher)
                .Include(tp => tp.Pupil)
                .Where(tp => tp.Pupil.Name == studentName)
                .Select(tp => tp.Teacher)
                .ToArray();

            return teachers;
        }
    }
}
