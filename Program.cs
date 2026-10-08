using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqGyakorlo
{
    class Program
    {
        static void Main(string[] args)
        {
            // A feladatok leírását a Feladatlap.md fájlban találod.
            // Minden feladathoz tartozik egy Feladat##() metódus itt lent.
            // Írd meg a LINQ lekérdezést a metódus törzsében, majd
            // vedd ki a kommentet a hívása elől, hogy lásd az eredményt.

            Feladat01();
            Feladat02();
            Feladat03();
            Feladat04();
            Feladat05();
            Feladat06();
            Feladat07();
            Feladat08();
            Feladat09();
            Feladat10();
            Feladat11();
            Feladat12();
            Feladat13();
            Feladat14();
            Feladat15();
            Feladat16();
            Feladat17();
            Feladat18();
            Feladat19();
            Feladat20();
            Feladat21();
            Feladat22();
            Feladat23();
            // Feladat09();
            // Feladat10();
            // Feladat11();
            // Feladat12();
            // Feladat13();
            // Feladat14();
            // Feladat15();
            // Feladat16();
            // Feladat17();
            // Feladat18();
            // Feladat19();
            // Feladat20();
            // Feladat21();
            // Feladat22();
            // Feladat23();
            // Feladat24();
            // Feladat25();
            // Feladat26();
            // Feladat27();
            // Feladat28();
            // Feladat29();
            // Feladat30();
            // Feladat31();
            // Feladat32();
            // Feladat33();
            // Feladat34();
            // Feladat35();
            // Feladat36();
            // Feladat37();
            // Feladat38();
            // Feladat39();
            // Feladat40();
        }

        // ---------- 1. Szűrés — Where ----------

        // 1. Hallgatók, akiknek 4.0 fölötti az átlaga.
        static void Feladat01()
        {
            var query = SampleData.Students
                .Where(s => s.GradeAverage > 4.0);

            Console.WriteLine("1. Hallgatók, akiknek 4.0 fölötti az átlaga:");
            foreach (var s in query)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // 2. Budapesti hallgatók.
        static void Feladat02()
        {
            var budapestiek = SampleData.Students
                .Where(s => string.Equals(s.City, "Budapest", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("2. Budapesti hallgatók:");
            foreach (var s in budapestiek)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // 3. Kurzusok, amelyek kreditértéke legalább 5.
        static void Feladat03()
        {
            var kurzusok = SampleData.Courses
                .Where(c => c.Credit >= 5);

            Console.WriteLine("3. Kurzusok, amelyek kreditértéke legalább 5:");
            foreach (var c in kurzusok)
                Console.WriteLine(c);
            Console.WriteLine();
        }

        // 4. Hallgatók 20-23 év között (határokkal), akik nem budapestiek.
        static void Feladat04()
        {
            var students = SampleData.Students
                .Where(s => s.Age >= 20 && s.Age <= 23 && !string.Equals(s.City, "Budapest", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("4. 20-23 év közötti, nem budapesti hallgatók:");
            foreach (var s in students)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // ---------- 2. Vetítés — Select, SelectMany ----------

        // 5. Csak a hallgatók nevei.
        static void Feladat05()
        {
            var names = SampleData.Students
                .Select(s => s.Name);

            Console.WriteLine("5. Csak a hallgatók nevei:");
            foreach (var n in names)
                Console.WriteLine(n);
            Console.WriteLine();
        }

        // 6. Anonim típusú lista: Name, GradeAverage.
        static void Feladat06()
        {
            var list = SampleData.Students
                .Select(s => new { s.Name, s.GradeAverage });

            Console.WriteLine("6. Név és átlag (anonim típus):");
            foreach (var item in list)
                Console.WriteLine($"{item.Name} - {item.GradeAverage:0.00}");
            Console.WriteLine();
        }

        // 7. Kurzus neve + a kurzust tartó tanár neve (Select, Join nélkül).
        static void Feladat07()
        {
            var q = SampleData.Courses
                .Select(c => new
                {
                    CourseName = c.Name,
                    TeacherName = SampleData.Teachers.FirstOrDefault(t => t.Id == c.TeacherId)?.Name ?? "(ismeretlen)"
                });

            Console.WriteLine("7. Kurzus + tanár neve (Select, Join nélkül):");
            foreach (var it in q)
                Console.WriteLine($"{it.CourseName} — {it.TeacherName}");
            Console.WriteLine();
        }

        // 8. SelectMany: beiratkozások lapos listája hallgató névvel.
        static void Feladat08()
        {
            var flat = SampleData.Students
                .SelectMany(s => SampleData.Enrollments
                    .Where(e => e.StudentId == s.Id)
                    .Select(e => new { StudentName = s.Name, e.CourseId, e.Grade }));

            Console.WriteLine("8. Beiratkozások lapos listája (SelectMany):");
            foreach (var e in flat)
                Console.WriteLine($"{e.StudentName} - CourseId={e.CourseId}, Grade={e.Grade}");
            Console.WriteLine();
        }

        // ---------- 3. Rendezés — OrderBy, ThenBy, Reverse ----------

        // 9. Hallgatók átlag szerint csökkenő sorrendben.
        static void Feladat09()
        {
            var ordered = SampleData.Students
                .OrderByDescending(s => s.GradeAverage);

            Console.WriteLine("9. Hallgatók átlag szerint csökkenő sorrendben:");
            foreach (var s in ordered)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // 10. Hallgatók város szerint, majd név szerint növekvő sorrendben.
        static void Feladat10()
        {
            var ordered = SampleData.Students
                .OrderBy(s => s.City)
                .ThenBy(s => s.Name);

            Console.WriteLine("10. Hallgatók város szerint, majd név szerint növekvő sorrendben:");
            foreach (var s in ordered)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // 11. Kurzusok eredeti sorrendjének megfordítása (Reverse).
        static void Feladat11()
        {
            var reversed = SampleData.Courses.AsEnumerable().Reverse();

            Console.WriteLine("11. Kurzusok eredeti sorrendjének megfordítása (Reverse):");
            foreach (var c in reversed)
                Console.WriteLine(c);
            Console.WriteLine();
        }

        // ---------- 4. Csoportosítás — GroupBy ----------

        // 12. Hallgatók száma városonként.
        static void Feladat12()
        {
            var grouped = SampleData.Students
                .GroupBy(s => s.City)
                .Select(g => new { City = g.Key, Count = g.Count() })
                .OrderBy(g => g.City);

            Console.WriteLine("12. Hallgatók száma városonként:");
            foreach (var g in grouped)
                Console.WriteLine($"{g.City}: {g.Count}");
            Console.WriteLine();
        }

        // 13. Átlagos tanulmányi átlag városonként.
        static void Feladat13()
        {
            var avgByCity = SampleData.Students
                .GroupBy(s => s.City)
                .Select(g => new { City = g.Key, Avg = g.Average(s => s.GradeAverage) })
                .OrderBy(x => x.City);

            Console.WriteLine("13. Átlagos tanulmányi átlag városonként:");
            foreach (var x in avgByCity)
                Console.WriteLine($"{x.City}: {x.Avg:0.00}");
            Console.WriteLine();
        }

        // 14. Kurzusnevek kategóriánként.
        static void Feladat14()
        {
            var byCategory = SampleData.Courses
                .GroupBy(c => c.Category)
                .Select(g => new { Category = g.Key, Courses = g.Select(c => c.Name).ToList() })
                .OrderBy(g => g.Category);

            Console.WriteLine("14. Kurzusnevek kategóriánként:");
            foreach (var g in byCategory)
            {
                Console.WriteLine(g.Category + ":");
                foreach (var name in g.Courses)
                    Console.WriteLine("  " + name);
            }
            Console.WriteLine();
        }

        // ---------- 5. Összekapcsolás — Join, GroupJoin ----------

        // 15. Enrollments + Students Join: hallgató neve minden beiratkozáshoz.
        static void Feladat15()
        {
            var q = SampleData.Enrollments
                .Join(SampleData.Students,
                    e => e.StudentId,
                    s => s.Id,
                    (e, s) => new { e.CourseId, e.Grade, StudentName = s.Name });

            Console.WriteLine("15. Enrollments + Students Join (hallgató neve minden beiratkozáshoz):");
            foreach (var item in q)
                Console.WriteLine($"{item.StudentName} - CourseId={item.CourseId}, Grade={item.Grade}");
            Console.WriteLine();
        }

        // 16. Háromtáblás Join: hallgató neve, kurzus neve, érdemjegy.
        static void Feladat16()
        {
            var q = SampleData.Enrollments
                .Join(SampleData.Students,
                    e => e.StudentId,
                    s => s.Id,
                    (e, s) => new { e, Student = s })
                .Join(SampleData.Courses,
                    es => es.e.CourseId,
                    c => c.Id,
                    (es, c) => new { StudentName = es.Student.Name, CourseName = c.Name, Grade = es.e.Grade });

            Console.WriteLine("16. Háromtáblás Join: hallgató neve, kurzus neve, érdemjegy:");
            foreach (var item in q)
                Console.WriteLine($"{item.StudentName} - {item.CourseName} - Grade={item.Grade}");
            Console.WriteLine();
        }

        // 17. GroupJoin: hallgatónként a beiratkozásai (azok is, akiknek nincs).
        static void Feladat17()
        {
            var q = SampleData.Students
                .GroupJoin(SampleData.Enrollments,
                    s => s.Id,
                    e => e.StudentId,
                    (s, enrolls) => new { Student = s, Enrollments = enrolls });

            Console.WriteLine("17. GroupJoin: hallgatónként a beiratkozásai (akár üres is):");
            foreach (var item in q)
            {
                Console.WriteLine(item.Student.Name + ":");
                if (item.Enrollments.Any())
                {
                    foreach (var e in item.Enrollments)
                    {
                        var courseName = SampleData.Courses.FirstOrDefault(c => c.Id == e.CourseId)?.Name ?? "(ismeretlen kurzus)";
                        Console.WriteLine($"  {courseName} - Grade={e.Grade}");
                    }
                }
                else
                {
                    Console.WriteLine("  (nincs beiratkozása)");
                }
            }
            Console.WriteLine();
        }

        // ---------- 6. Halmazműveletek — Distinct, Union, Intersect, Except, Concat, Zip ----------

        // 18. Hány különböző város van a hallgatók között (Distinct).
        static void Feladat18()
        {
            var distinctCities = SampleData.Students
                .Select(s => s.City)
                .Distinct()
                .ToList();

            Console.WriteLine("18. Hány különböző város van a hallgatók között (Distinct):");
            Console.WriteLine($"{distinctCities.Count} város:");
            foreach (var c in distinctCities)
                Console.WriteLine("  " + c);
            Console.WriteLine();
        }

        // 19. Különböző kurzuskategóriák (Distinct).
        static void Feladat19()
        {
            var categories = SampleData.Courses
                .Select(c => c.Category)
                .Distinct()
                .ToList();

            Console.WriteLine("19. Különböző kurzuskategóriák (Distinct):");
            foreach (var cat in categories)
                Console.WriteLine("  " + cat);
            Console.WriteLine();
        }

        // 20. Union, Intersect, Except a "kiváló" (átlag >= 4.5) és "budapesti" hallgatók nevei között.
        static void Feladat20()
        {
            var kivalo = SampleData.Students
                .Where(s => s.GradeAverage >= 4.5)
                .Select(s => s.Name);

            var budapestiek = SampleData.Students
                .Where(s => string.Equals(s.City, "Budapest", StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Name);

            var union = kivalo.Union(budapestiek);
            var intersect = kivalo.Intersect(budapestiek);
            var except = kivalo.Except(budapestiek);

            Console.WriteLine("20. Union / Intersect / Except a 'kiváló' és 'budapesti' hallgatók nevei között:");
            Console.WriteLine("Union:");
            foreach (var n in union) Console.WriteLine("  " + n);
            Console.WriteLine("Intersect (kiváló és budapesti):");
            foreach (var n in intersect) Console.WriteLine("  " + n);
            Console.WriteLine("Except (kiváló, de nem budapesti):");
            foreach (var n in except) Console.WriteLine("  " + n);
            Console.WriteLine();
        }

        // 21. Concat: Matematika + Informatika kurzusnevek.
        static void Feladat21()
        {
            var math = SampleData.Courses
                .Where(c => c.Category == "Matematika")
                .Select(c => c.Name);

            var info = SampleData.Courses
                .Where(c => c.Category == "Informatika")
                .Select(c => c.Name);

            var concat = math.Concat(info);

            Console.WriteLine("21. Concat: Matematika + Informatika kurzusnevek:");
            foreach (var n in concat) Console.WriteLine("  " + n);
            Console.WriteLine();
        }

        // 22. Zip: első 4 hallgató neve + első 4 kurzus neve párban.
        static void Feladat22()
        {
            var students = SampleData.Students.Select(s => s.Name).Take(4);
            var courses = SampleData.Courses.Select(c => c.Name).Take(4);

            var zipped = students.Zip(courses, (s, c) => new { Student = s, Course = c });

            Console.WriteLine("22. Zip: első 4 hallgató neve + első 4 kurzus neve párban:");
            foreach (var p in zipped)
                Console.WriteLine($"  {p.Student}  —  {p.Course}");
            Console.WriteLine();
        }

        // ---------- 7. Aggregálás — Count, Sum, Average, Min, Max, Aggregate ----------

        // 23. Hallgatók száma összesen, illetve akiknek átlaga > 4.0 (Count).
        static void Feladat23()
        {
            var total = SampleData.Students.Count();
            var above4 = SampleData.Students.Count(s => s.GradeAverage > 4.0);

            Console.WriteLine("23. Hallgatók száma összesen, illetve akiknek átlaga > 4.0:");
            Console.WriteLine($"Összesen: {total}");
            Console.WriteLine($"Átlaga > 4.0: {above4}");
            Console.WriteLine();
        }

        // 24. Az összes kurzus kredit-összege (Sum).
        static void Feladat24()
        {
            // TODO
        }

        // 25. Hallgatók átlagéletkora (Average).
        static void Feladat25()
        {
            // TODO
        }

        // 26. Legfiatalabb és legidősebb hallgató életkora (Min, Max).
        static void Feladat26()
        {
            // TODO
        }

        // 27. Aggregate: hallgatónevek vesszővel elválasztva egy stringbe.
        static void Feladat27()
        {
            // TODO
        }

        // ---------- 8. Elemkiválasztás — First, Last, Single, ElementAt ----------

        // 28. Első szegedi hallgató (First/FirstOrDefault).
        static void Feladat28()
        {
            // TODO
        }

        // 29. Az egyetlen "Lakatos Kata" nevű hallgató (Single/SingleOrDefault),
        //     majd egy olyan eset kipróbálása try-catch-csel, ahol több találat van.
        static void Feladat29()
        {
            // TODO
        }

        // 30. A 3. indexű (0-tól) hallgató (ElementAt).
        static void Feladat30()
        {
            // TODO
        }

        // ---------- 9. Particionálás — Skip, Take, SkipWhile, TakeWhile, Chunk ----------

        // 31. TOP 3 hallgató átlag szerint (Take).
        static void Feladat31()
        {
            // TODO
        }

        // 32. Az első 3 utáni hallgatók (Skip).
        static void Feladat32()
        {
            // TODO
        }

        // 33. Életkor szerint rendezve: TakeWhile (21 évnél fiatalabbak), majd SkipWhile (a többi).
        static void Feladat33()
        {
            // TODO
        }

        // 34. Hallgatók felbontása 4 fős csoportokra (Chunk).
        static void Feladat34()
        {
            // TODO
        }

        // ---------- 10. Egyéb — Any, All, Contains, ToDictionary, ToHashSet, DefaultIfEmpty ----------

        // 35. Van-e hallgató 2.5 alatti átlaggal (Any).
        static void Feladat35()
        {
            // TODO
        }

        // 36. Minden hallgató 18 évesnél idősebb-e (All).
        static void Feladat36()
        {
            // TODO
        }

        // 37. Szerepel-e "Pécs" a városok között (Contains).
        static void Feladat37()
        {
            // TODO
        }

        // 38. Dictionary<int, string> a hallgatók Id-je és neve alapján (ToDictionary).
        static void Feladat38()
        {
            // TODO
        }

        // 39. HashSet<string> a kurzuskategóriákból (ToHashSet).
        static void Feladat39()
        {
            // TODO
        }

        // 40. Nem létező kurzushoz tartozó beiratkozások, DefaultIfEmpty kezeléssel.
        static void Feladat40()
        {
            // TODO
        }
    }
}
