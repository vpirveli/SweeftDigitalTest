using Microsoft.EntityFrameworkCore;


namespace SweeftDigitalTest
{
    internal class SchoolContext : DbContext
    {
        readonly string _connectionString;

        public SchoolContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Pupil> Pupil { get; set; }
        public DbSet<TeacherPupil> TeacherPupil { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL server connection string
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherPupil>()
                .HasKey(tp => tp.Id);

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Teacher)
                .WithMany(t => t.TeacherPupils)
                .HasForeignKey(tp => tp.TeacherId);

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Pupil)
                .WithMany(p => p.TeacherPupils)
                .HasForeignKey(tp => tp.PupilId);
        }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Subject { get; set; }

        public ICollection<TeacherPupil> TeacherPupils { get; set; }
    }

    public class Pupil
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int Grade { get; set; }

        public ICollection<TeacherPupil> TeacherPupils { get; set; }
    }

    public class TeacherPupil
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int PupilId { get; set; }
        public Teacher Teacher { get; set; }
        public Pupil Pupil { get; set; }
    }
}

