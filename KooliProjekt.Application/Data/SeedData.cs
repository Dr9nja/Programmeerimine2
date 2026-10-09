using System;
using System.Collections.Generic;
using System.Linq;
using KooliProjekt.Application.Data.Entities;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
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

            var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, FirstName = "Andres", LastName = "Ilves", Email = "andres.ilves@kool.ee", Department = "Matemaatika", HiredAt = new DateTime(2006, 8, 15) },
                new Teacher { Id = 2, FirstName = "Kristi", LastName = "Kukk", Email = "kristi.kukk@kool.ee", Department = "Keeled", HiredAt = new DateTime(2007, 8, 15) },
                new Teacher { Id = 3, FirstName = "Martin", LastName = "Põld", Email = "martin.pold@kool.ee", Department = "Keeled", HiredAt = new DateTime(2008, 8, 15) },
                new Teacher { Id = 4, FirstName = "Kairi", LastName = "Rebane", Email = "kairi.rebane@kool.ee", Department = "Ajalugu", HiredAt = new DateTime(2009, 8, 15) },
                new Teacher { Id = 5, FirstName = "Tarmo", LastName = "Ots", Email = "tarmo.ots@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2010, 8, 15) },
                new Teacher { Id = 6, FirstName = "Anneli", LastName = "Tamm", Email = "anneli.tamm@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2011, 8, 15) },
                new Teacher { Id = 7, FirstName = "Peeter", LastName = "Saar", Email = "peeter.saar@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2012, 8, 15) },
                new Teacher { Id = 8, FirstName = "Maarja", LastName = "Mägi", Email = "maarja.magi@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2013, 8, 15) },
                new Teacher { Id = 9, FirstName = "Jaan", LastName = "Sepp", Email = "jaan.sepp@kool.ee", Department = "Infotehnoloogia", HiredAt = new DateTime(2014, 8, 15) },
                new Teacher { Id = 10, FirstName = "Liina", LastName = "Kask", Email = "liina.kask@kool.ee", Department = "Infotehnoloogia", HiredAt = new DateTime(2015, 8, 15) },
                new Teacher { Id = 11, FirstName = "Siim", LastName = "Ilves", Email = "siim.ilves@kool.ee", Department = "Infotehnoloogia", HiredAt = new DateTime(2016, 8, 15) },
                new Teacher { Id = 12, FirstName = "Eleri", LastName = "Kukk", Email = "eleri.kukk@kool.ee", Department = "Infotehnoloogia", HiredAt = new DateTime(2017, 8, 15) },
                new Teacher { Id = 13, FirstName = "Toomas", LastName = "Põld", Email = "toomas.pold@kool.ee", Department = "Kunstid", HiredAt = new DateTime(2018, 8, 15) },
                new Teacher { Id = 14, FirstName = "Piret", LastName = "Rebane", Email = "piret.rebane@kool.ee", Department = "Kunstid", HiredAt = new DateTime(2019, 8, 15) },
                new Teacher { Id = 15, FirstName = "Arvo", LastName = "Ots", Email = "arvo.ots@kool.ee", Department = "Liikumisõpetus", HiredAt = new DateTime(2020, 8, 15) },
                new Teacher { Id = 16, FirstName = "Katrin", LastName = "Tamm", Email = "katrin.tamm@kool.ee", Department = "Ühiskonnaained", HiredAt = new DateTime(2021, 8, 15) },
                new Teacher { Id = 17, FirstName = "Raul", LastName = "Saar", Email = "raul.saar@kool.ee", Department = "Ühiskonnaained", HiredAt = new DateTime(2022, 8, 15) },
                new Teacher { Id = 18, FirstName = "Eve", LastName = "Mägi", Email = "eve.magi@kool.ee", Department = "Keeled", HiredAt = new DateTime(2023, 8, 15) },
                new Teacher { Id = 19, FirstName = "Marten", LastName = "Sepp", Email = "marten.sepp@kool.ee", Department = "Keeled", HiredAt = new DateTime(2006, 8, 15) },
                new Teacher { Id = 20, FirstName = "Kadri", LastName = "Kask", Email = "kadri.kask@kool.ee", Department = "Keeled", HiredAt = new DateTime(2007, 8, 15) },
                new Teacher { Id = 21, FirstName = "Aivar", LastName = "Ilves", Email = "aivar.ilves@kool.ee", Department = "Matemaatika", HiredAt = new DateTime(2008, 8, 15) },
                new Teacher { Id = 22, FirstName = "Maris", LastName = "Kukk", Email = "maris.kukk@kool.ee", Department = "Matemaatika", HiredAt = new DateTime(2009, 8, 15) },
                new Teacher { Id = 23, FirstName = "Rene", LastName = "Põld", Email = "rene.pold@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2010, 8, 15) },
                new Teacher { Id = 24, FirstName = "Anu", LastName = "Rebane", Email = "anu.rebane@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2011, 8, 15) },
                new Teacher { Id = 25, FirstName = "Jüri", LastName = "Ots", Email = "juri.ots@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2012, 8, 15) },
                new Teacher { Id = 26, FirstName = "Külli", LastName = "Tamm", Email = "kulli.tamm@kool.ee", Department = "Ajalugu", HiredAt = new DateTime(2013, 8, 15) },
                new Teacher { Id = 27, FirstName = "Mihkel", LastName = "Saar", Email = "mihkel.saar@kool.ee", Department = "Loodusteadused", HiredAt = new DateTime(2014, 8, 15) },
                new Teacher { Id = 28, FirstName = "Epp", LastName = "Mägi", Email = "epp.magi@kool.ee", Department = "Infotehnoloogia", HiredAt = new DateTime(2015, 8, 15) },
                new Teacher { Id = 29, FirstName = "Sander", LastName = "Sepp", Email = "sander.sepp@kool.ee", Department = "Infotehnoloogia", HiredAt = new DateTime(2016, 8, 15) },
                new Teacher { Id = 30, FirstName = "Triin", LastName = "Kask", Email = "triin.kask@kool.ee", Department = "Infotehnoloogia", HiredAt = new DateTime(2017, 8, 15) },
                new Teacher { Id = 31, FirstName = "Urmas", LastName = "Ilves", Email = "urmas.ilves@kool.ee", Department = "Keeled", HiredAt = new DateTime(2018, 8, 15) },
                new Teacher { Id = 32, FirstName = "Heli", LastName = "Kukk", Email = "heli.kukk@kool.ee", Department = "Keeled", HiredAt = new DateTime(2019, 8, 15) },
                new Teacher { Id = 33, FirstName = "Priit", LastName = "Põld", Email = "priit.pold@kool.ee", Department = "Ühiskonnaained", HiredAt = new DateTime(2020, 8, 15) },
                new Teacher { Id = 34, FirstName = "Merle", LastName = "Rebane", Email = "merle.rebane@kool.ee", Department = "Kunstid", HiredAt = new DateTime(2021, 8, 15) },
                new Teacher { Id = 35, FirstName = "Taavi", LastName = "Ots", Email = "taavi.ots@kool.ee", Department = "Liikumisõpetus", HiredAt = new DateTime(2022, 8, 15) }
            };

            var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "Mari", LastName = "Tamm", Email = "mari.tamm@opilane.kool.ee", DateOfBirth = new DateTime(2007, 1, 12), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 2, FirstName = "Karl", LastName = "Tamm", Email = "karl.tamm@opilane.kool.ee", DateOfBirth = new DateTime(2008, 2, 8), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 3, FirstName = "Liis", LastName = "Tamm", Email = "liis.tamm@opilane.kool.ee", DateOfBirth = new DateTime(2009, 3, 21), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 4, FirstName = "Markus", LastName = "Tamm", Email = "markus.tamm@opilane.kool.ee", DateOfBirth = new DateTime(2007, 4, 5), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 5, FirstName = "Kadi", LastName = "Tamm", Email = "kadi.tamm@opilane.kool.ee", DateOfBirth = new DateTime(2008, 5, 17), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 6, FirstName = "Rasmus", LastName = "Tamm", Email = "rasmus.tamm@opilane.kool.ee", DateOfBirth = new DateTime(2009, 6, 2), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 7, FirstName = "Annika", LastName = "Tamm", Email = "annika.tamm@opilane.kool.ee", DateOfBirth = new DateTime(2007, 7, 14), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 8, FirstName = "Mari", LastName = "Saar", Email = "mari.saar@opilane.kool.ee", DateOfBirth = new DateTime(2008, 8, 9), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 9, FirstName = "Karl", LastName = "Saar", Email = "karl.saar@opilane.kool.ee", DateOfBirth = new DateTime(2009, 9, 23), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 10, FirstName = "Liis", LastName = "Saar", Email = "liis.saar@opilane.kool.ee", DateOfBirth = new DateTime(2007, 10, 11), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 11, FirstName = "Markus", LastName = "Saar", Email = "markus.saar@opilane.kool.ee", DateOfBirth = new DateTime(2008, 11, 4), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 12, FirstName = "Kadi", LastName = "Saar", Email = "kadi.saar@opilane.kool.ee", DateOfBirth = new DateTime(2009, 12, 19), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 13, FirstName = "Rasmus", LastName = "Saar", Email = "rasmus.saar@opilane.kool.ee", DateOfBirth = new DateTime(2007, 1, 27), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 14, FirstName = "Annika", LastName = "Saar", Email = "annika.saar@opilane.kool.ee", DateOfBirth = new DateTime(2008, 2, 13), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 15, FirstName = "Mari", LastName = "Mägi", Email = "mari.magi@opilane.kool.ee", DateOfBirth = new DateTime(2009, 3, 7), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 16, FirstName = "Karl", LastName = "Mägi", Email = "karl.magi@opilane.kool.ee", DateOfBirth = new DateTime(2007, 4, 22), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 17, FirstName = "Liis", LastName = "Mägi", Email = "liis.magi@opilane.kool.ee", DateOfBirth = new DateTime(2008, 5, 10), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 18, FirstName = "Markus", LastName = "Mägi", Email = "markus.magi@opilane.kool.ee", DateOfBirth = new DateTime(2009, 6, 16), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 19, FirstName = "Kadi", LastName = "Mägi", Email = "kadi.magi@opilane.kool.ee", DateOfBirth = new DateTime(2007, 7, 3), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 20, FirstName = "Rasmus", LastName = "Mägi", Email = "rasmus.magi@opilane.kool.ee", DateOfBirth = new DateTime(2008, 8, 25), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 21, FirstName = "Annika", LastName = "Mägi", Email = "annika.magi@opilane.kool.ee", DateOfBirth = new DateTime(2009, 9, 15), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 22, FirstName = "Mari", LastName = "Sepp", Email = "mari.sepp@opilane.kool.ee", DateOfBirth = new DateTime(2007, 10, 6), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 23, FirstName = "Karl", LastName = "Sepp", Email = "karl.sepp@opilane.kool.ee", DateOfBirth = new DateTime(2008, 11, 28), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 24, FirstName = "Liis", LastName = "Sepp", Email = "liis.sepp@opilane.kool.ee", DateOfBirth = new DateTime(2009, 12, 9), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 25, FirstName = "Markus", LastName = "Sepp", Email = "markus.sepp@opilane.kool.ee", DateOfBirth = new DateTime(2007, 1, 18), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 26, FirstName = "Kadi", LastName = "Sepp", Email = "kadi.sepp@opilane.kool.ee", DateOfBirth = new DateTime(2008, 2, 24), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 27, FirstName = "Rasmus", LastName = "Sepp", Email = "rasmus.sepp@opilane.kool.ee", DateOfBirth = new DateTime(2009, 3, 14), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 28, FirstName = "Annika", LastName = "Sepp", Email = "annika.sepp@opilane.kool.ee", DateOfBirth = new DateTime(2007, 4, 30), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 29, FirstName = "Mari", LastName = "Kask", Email = "mari.kask@opilane.kool.ee", DateOfBirth = new DateTime(2008, 5, 20), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 30, FirstName = "Karl", LastName = "Kask", Email = "karl.kask@opilane.kool.ee", DateOfBirth = new DateTime(2009, 6, 11), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 31, FirstName = "Liis", LastName = "Kask", Email = "liis.kask@opilane.kool.ee", DateOfBirth = new DateTime(2007, 7, 26), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 32, FirstName = "Markus", LastName = "Kask", Email = "markus.kask@opilane.kool.ee", DateOfBirth = new DateTime(2008, 8, 17), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 33, FirstName = "Kadi", LastName = "Kask", Email = "kadi.kask@opilane.kool.ee", DateOfBirth = new DateTime(2009, 9, 5), EnrolledAt = new DateTime(2024, 9, 1) },
                new Student { Id = 34, FirstName = "Rasmus", LastName = "Kask", Email = "rasmus.kask@opilane.kool.ee", DateOfBirth = new DateTime(2007, 10, 25), EnrolledAt = new DateTime(2025, 9, 1) },
                new Student { Id = 35, FirstName = "Annika", LastName = "Kask", Email = "annika.kask@opilane.kool.ee", DateOfBirth = new DateTime(2008, 11, 12), EnrolledAt = new DateTime(2024, 9, 1) }
            };

            var courses = new List<Course>
            {
                new Course { Id = 1, Code = "MAT101", Name = "Matemaatika", Description = "Matemaatika põhikursus", Credits = 4, TeacherId = 1 },
                new Course { Id = 2, Code = "EST101", Name = "Eesti keel", Description = "Eesti keele ja grammatika alused", Credits = 3, TeacherId = 2 },
                new Course { Id = 3, Code = "ENG101", Name = "Inglise keel", Description = "Inglise keele suhtlus ja grammatika", Credits = 3, TeacherId = 3 },
                new Course { Id = 4, Code = "HIS101", Name = "Eesti ajalugu", Description = "Eesti ajaloo tähtsamad perioodid", Credits = 2, TeacherId = 4 },
                new Course { Id = 5, Code = "BIO101", Name = "Bioloogia", Description = "Elusorganismid ja nende keskkond", Credits = 3, TeacherId = 5 },
                new Course { Id = 6, Code = "CHE101", Name = "Keemia", Description = "Ainete omadused ja keemilised reaktsioonid", Credits = 3, TeacherId = 6 },
                new Course { Id = 7, Code = "PHY101", Name = "Füüsika", Description = "Füüsika põhimõisted ja liikumine", Credits = 3, TeacherId = 7 },
                new Course { Id = 8, Code = "GEO101", Name = "Geograafia", Description = "Maailma piirkonnad ja loodus", Credits = 2, TeacherId = 8 },
                new Course { Id = 9, Code = "INF101", Name = "Programmeerimise alused", Description = "Algoritmiline mõtlemine ja programmeerimine", Credits = 4, TeacherId = 9 },
                new Course { Id = 10, Code = "INF102", Name = "Veebiarendus", Description = "Veebilehtede loomise alused", Credits = 4, TeacherId = 10 },
                new Course { Id = 11, Code = "INF103", Name = "Andmebaasid", Description = "Relatsiooniliste andmebaaside modelleerimine", Credits = 4, TeacherId = 11 },
                new Course { Id = 12, Code = "INF104", Name = "Arvutivõrgud", Description = "Arvutivõrkude ja interneti alused", Credits = 3, TeacherId = 12 },
                new Course { Id = 13, Code = "ART101", Name = "Kunst", Description = "Kunsti põhitehnikad ja visuaalne väljendus", Credits = 2, TeacherId = 13 },
                new Course { Id = 14, Code = "MUS101", Name = "Muusika", Description = "Muusika kuulamine ja muusikaline väljendus", Credits = 2, TeacherId = 14 },
                new Course { Id = 15, Code = "PE101", Name = "Kehaline kasvatus", Description = "Liikumine ja kehalise vormi arendamine", Credits = 2, TeacherId = 15 },
                new Course { Id = 16, Code = "CIV101", Name = "Ühiskonnaõpetus", Description = "Kodanik, riik ja ühiskonna toimimine", Credits = 2, TeacherId = 16 },
                new Course { Id = 17, Code = "ECO101", Name = "Majandusõpetus", Description = "Isiklik rahandus ja majanduse alused", Credits = 2, TeacherId = 17 },
                new Course { Id = 18, Code = "LIT101", Name = "Maailmakirjandus", Description = "Valik maailmakirjanduse teoseid", Credits = 3, TeacherId = 18 },
                new Course { Id = 19, Code = "RUS101", Name = "Vene keel", Description = "Vene keele sõnavara ja suhtlus", Credits = 3, TeacherId = 19 },
                new Course { Id = 20, Code = "FIN101", Name = "Soome keel", Description = "Soome keele algkursus", Credits = 3, TeacherId = 20 },
                new Course { Id = 21, Code = "MAT102", Name = "Algebra", Description = "Võrrandid, avaldised ja funktsioonid", Credits = 4, TeacherId = 21 },
                new Course { Id = 22, Code = "MAT103", Name = "Geomeetria", Description = "Tasandilised kujundid ja mõõtmine", Credits = 3, TeacherId = 22 },
                new Course { Id = 23, Code = "BIO102", Name = "Inimese anatoomia", Description = "Inimese keha ehitus ja talitlus", Credits = 3, TeacherId = 23 },
                new Course { Id = 24, Code = "CHE102", Name = "Orgaaniline keemia", Description = "Süsinikuühendid igapäevaelus", Credits = 3, TeacherId = 24 },
                new Course { Id = 25, Code = "PHY102", Name = "Mehaanika", Description = "Jõud, energia ja mehaaniline liikumine", Credits = 3, TeacherId = 25 },
                new Course { Id = 26, Code = "HIS102", Name = "Maailma ajalugu", Description = "Maailma ajaloo olulisemad sündmused", Credits = 2, TeacherId = 26 },
                new Course { Id = 27, Code = "GEO102", Name = "Keskkonnageograafia", Description = "Inimtegevus ja keskkonnamuutused", Credits = 2, TeacherId = 27 },
                new Course { Id = 28, Code = "INF105", Name = "Andmeturve", Description = "Turvalise andmekasutuse põhimõtted", Credits = 3, TeacherId = 28 },
                new Course { Id = 29, Code = "INF106", Name = "Tarkvaraarendus", Description = "Tarkvaraprojekti kavandamine ja teostamine", Credits = 4, TeacherId = 29 },
                new Course { Id = 30, Code = "INF107", Name = "Andmestruktuurid", Description = "Levinud andmestruktuurid ja nende kasutus", Credits = 4, TeacherId = 30 },
                new Course { Id = 31, Code = "EST102", Name = "Kirjanduse analüüs", Description = "Ilukirjandusliku teksti lugemine ja analüüs", Credits = 3, TeacherId = 31 },
                new Course { Id = 32, Code = "ENG102", Name = "Inglise keele grammatika", Description = "Inglise keele grammatika süvendatud kursus", Credits = 3, TeacherId = 32 },
                new Course { Id = 33, Code = "CIV102", Name = "Inimõigused", Description = "Inimõigused ja nende kaitse", Credits = 2, TeacherId = 33 },
                new Course { Id = 34, Code = "ART102", Name = "Kujutav kunst", Description = "Joonistamise ja maalimise praktilised tööd", Credits = 2, TeacherId = 34 },
                new Course { Id = 35, Code = "PE102", Name = "Tervis ja liikumine", Description = "Tervislik eluviis ja aktiivne liikumine", Credits = 2, TeacherId = 35 }
            };

            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentId = 1, CourseId = 1, EnrolledAt = new DateTime(2025, 9, 1) },
                new Enrollment { StudentId = 2, CourseId = 2, EnrolledAt = new DateTime(2025, 9, 1) },
                new Enrollment { StudentId = 3, CourseId = 3, EnrolledAt = new DateTime(2025, 9, 2) },
                new Enrollment { StudentId = 4, CourseId = 4, EnrolledAt = new DateTime(2025, 9, 2) },
                new Enrollment { StudentId = 5, CourseId = 5, EnrolledAt = new DateTime(2025, 9, 3) },
                new Enrollment { StudentId = 6, CourseId = 6, EnrolledAt = new DateTime(2025, 9, 3) },
                new Enrollment { StudentId = 7, CourseId = 7, EnrolledAt = new DateTime(2025, 9, 4) },
                new Enrollment { StudentId = 8, CourseId = 8, EnrolledAt = new DateTime(2025, 9, 4) },
                new Enrollment { StudentId = 9, CourseId = 9, EnrolledAt = new DateTime(2025, 9, 5) },
                new Enrollment { StudentId = 10, CourseId = 10, EnrolledAt = new DateTime(2025, 9, 5) },
                new Enrollment { StudentId = 11, CourseId = 11, EnrolledAt = new DateTime(2025, 9, 6) },
                new Enrollment { StudentId = 12, CourseId = 12, EnrolledAt = new DateTime(2025, 9, 6) },
                new Enrollment { StudentId = 13, CourseId = 13, EnrolledAt = new DateTime(2025, 9, 7) },
                new Enrollment { StudentId = 14, CourseId = 14, EnrolledAt = new DateTime(2025, 9, 7) },
                new Enrollment { StudentId = 15, CourseId = 15, EnrolledAt = new DateTime(2025, 9, 8) },
                new Enrollment { StudentId = 16, CourseId = 16, EnrolledAt = new DateTime(2025, 9, 8) },
                new Enrollment { StudentId = 17, CourseId = 17, EnrolledAt = new DateTime(2025, 9, 9) },
                new Enrollment { StudentId = 18, CourseId = 18, EnrolledAt = new DateTime(2025, 9, 9) },
                new Enrollment { StudentId = 19, CourseId = 19, EnrolledAt = new DateTime(2025, 9, 10) },
                new Enrollment { StudentId = 20, CourseId = 20, EnrolledAt = new DateTime(2025, 9, 10) },
                new Enrollment { StudentId = 21, CourseId = 21, EnrolledAt = new DateTime(2025, 9, 11) },
                new Enrollment { StudentId = 22, CourseId = 22, EnrolledAt = new DateTime(2025, 9, 11) },
                new Enrollment { StudentId = 23, CourseId = 23, EnrolledAt = new DateTime(2025, 9, 12) },
                new Enrollment { StudentId = 24, CourseId = 24, EnrolledAt = new DateTime(2025, 9, 12) },
                new Enrollment { StudentId = 25, CourseId = 25, EnrolledAt = new DateTime(2025, 9, 13) },
                new Enrollment { StudentId = 26, CourseId = 26, EnrolledAt = new DateTime(2025, 9, 13) },
                new Enrollment { StudentId = 27, CourseId = 27, EnrolledAt = new DateTime(2025, 9, 14) },
                new Enrollment { StudentId = 28, CourseId = 28, EnrolledAt = new DateTime(2025, 9, 14) },
                new Enrollment { StudentId = 29, CourseId = 29, EnrolledAt = new DateTime(2025, 9, 15) },
                new Enrollment { StudentId = 30, CourseId = 30, EnrolledAt = new DateTime(2025, 9, 15) },
                new Enrollment { StudentId = 31, CourseId = 31, EnrolledAt = new DateTime(2025, 9, 16) },
                new Enrollment { StudentId = 32, CourseId = 32, EnrolledAt = new DateTime(2025, 9, 16) },
                new Enrollment { StudentId = 33, CourseId = 33, EnrolledAt = new DateTime(2025, 9, 17) },
                new Enrollment { StudentId = 34, CourseId = 34, EnrolledAt = new DateTime(2025, 9, 17) },
                new Enrollment { StudentId = 35, CourseId = 35, EnrolledAt = new DateTime(2025, 9, 18) }
            };

            context.Teachers.AddRange(teachers);
            context.Courses.AddRange(courses);
            context.Students.AddRange(students);
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
