using System;
using System.Linq;
using KooliProjekt.Application.Data.Entities;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        private static readonly string[] FirstNames =
        {
            "Mari", "Karl", "Liis", "Markus", "Kadi", "Rasmus", "Annika"
        };

        private static readonly string[] LastNames =
        {
            "Tamm", "Saar", "Mägi", "Sepp", "Kask"
        };

        private static readonly string[] TeacherFirstNames =
        {
            "Andres", "Kristi", "Martin", "Kairi", "Tarmo", "Anneli", "Peeter"
        };

        private static readonly string[] TeacherLastNames =
        {
            "Ilves", "Kukk", "Põld", "Rebane", "Ots"
        };

        private static readonly (string Code, string Name, string Department, int Credits)[] CourseData =
        {
            ("MAT101", "Matemaatika", "Matemaatika", 4),
            ("EST101", "Eesti keel", "Keeled", 3),
            ("ENG101", "Inglise keel", "Keeled", 3),
            ("HIS101", "Eesti ajalugu", "Ajalugu", 2),
            ("BIO101", "Bioloogia", "Loodusteadused", 3),
            ("CHE101", "Keemia", "Loodusteadused", 3),
            ("PHY101", "Füüsika", "Loodusteadused", 3),
            ("GEO101", "Geograafia", "Loodusteadused", 2),
            ("INF101", "Programmeerimise alused", "Infotehnoloogia", 4),
            ("INF102", "Veebiarendus", "Infotehnoloogia", 4),
            ("INF103", "Andmebaasid", "Infotehnoloogia", 4),
            ("INF104", "Arvutivõrgud", "Infotehnoloogia", 3),
            ("ART101", "Kunst", "Kunstid", 2),
            ("MUS101", "Muusika", "Kunstid", 2),
            ("PE101", "Kehaline kasvatus", "Liikumisõpetus", 2),
            ("CIV101", "Ühiskonnaõpetus", "Ühiskonnaained", 2),
            ("ECO101", "Majandusõpetus", "Ühiskonnaained", 2),
            ("LIT101", "Maailmakirjandus", "Keeled", 3),
            ("RUS101", "Vene keel", "Keeled", 3),
            ("FIN101", "Soome keel", "Keeled", 3),
            ("MAT102", "Algebra", "Matemaatika", 4),
            ("MAT103", "Geomeetria", "Matemaatika", 3),
            ("BIO102", "Inimese anatoomia", "Loodusteadused", 3),
            ("CHE102", "Orgaaniline keemia", "Loodusteadused", 3),
            ("PHY102", "Mehaanika", "Loodusteadused", 3),
            ("HIS102", "Maailma ajalugu", "Ajalugu", 2),
            ("GEO102", "Keskkonnageograafia", "Loodusteadused", 2),
            ("INF105", "Andmeturve", "Infotehnoloogia", 3),
            ("INF106", "Tarkvaraarendus", "Infotehnoloogia", 4),
            ("INF107", "Andmestruktuurid", "Infotehnoloogia", 4),
            ("EST102", "Kirjanduse analüüs", "Keeled", 3),
            ("ENG102", "Inglise keele grammatika", "Keeled", 3),
            ("CIV102", "Inimõigused", "Ühiskonnaained", 2),
            ("ART102", "Kujutav kunst", "Kunstid", 2),
            ("PE102", "Tervis ja liikumine", "Liikumisõpetus", 2)
        };

        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Students.Any() ||
                context.Teachers.Any() ||
                context.Courses.Any() ||
                context.Enrollments.Any())
            {
                if (context.Students.Count() >= 35 &&
                    context.Teachers.Count() >= 35 &&
                    context.Courses.Count() >= 35 &&
                    context.Enrollments.Count() >= 35)
                {
                    return;
                }

                throw new InvalidOperationException(
                    "Seed data was not added because the database contains a partial data set.");
            }

            var teachers = Enumerable.Range(0, 35)
                .Select(index =>
                {
                    var firstName = TeacherFirstNames[index % TeacherFirstNames.Length];
                    var lastName = TeacherLastNames[index / TeacherFirstNames.Length];

                    return new Teacher
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = $"{firstName.ToLowerInvariant()}.{ToEmailName(lastName)}@kool.ee",
                        Department = CourseData[index].Department,
                        HiredAt = new DateTime(2006 + index % 18, 8, 15)
                    };
                })
                .ToList();

            context.Teachers.AddRange(teachers);
            context.SaveChanges();

            var courses = CourseData
                .Select((course, index) => new Course
                {
                    Code = course.Code,
                    Name = course.Name,
                    Description = $"{course.Name} kursus kooliõpilastele.",
                    Credits = course.Credits,
                    TeacherId = teachers[index].Id
                })
                .ToList();

            context.Courses.AddRange(courses);

            var students = Enumerable.Range(0, 35)
                .Select(index =>
                {
                    var firstName = FirstNames[index % FirstNames.Length];
                    var lastName = LastNames[index / FirstNames.Length];

                    return new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = $"{firstName.ToLowerInvariant()}.{ToEmailName(lastName)}@opilane.kool.ee",
                        DateOfBirth = new DateTime(2007 + index % 3, 1 + index % 12, 1 + index % 27),
                        EnrolledAt = new DateTime(2024 + index % 2, 9, 1)
                    };
                })
                .ToList();

            context.Students.AddRange(students);
            context.SaveChanges();

            var enrollments = Enumerable.Range(0, students.Count)
                .SelectMany(studentIndex => Enumerable.Range(0, 3)
                    .Select(courseOffset => new Enrollment
                    {
                        StudentId = students[studentIndex].Id,
                        CourseId = courses[(studentIndex * 3 + courseOffset) % courses.Count].Id,
                        EnrolledAt = new DateTime(2025, 9, 1).AddDays((studentIndex + courseOffset) % 20)
                    }))
                .ToList();

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }

        private static string ToEmailName(string name)
        {
            return name.Replace("ä", "a")
                .Replace("ö", "o")
                .Replace("ü", "u")
                .Replace("õ", "o")
                .ToLowerInvariant();
        }
    }
}
