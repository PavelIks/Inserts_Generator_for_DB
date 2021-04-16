using System;
using System.Collections.Generic;
using System.IO;

namespace Inserts_Generator_for_DB
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            Dictionary<int, string> students = new Dictionary<int, string>(2000);
            Dictionary<int, string> teachers = new Dictionary<int, string>(300);

            for (int i = 1; i <= 2000; i++)
            {
                var a = random.Next(1, 6);
                switch (a)
                {
                    case 1:
                        students.Add(i, "Kolya");
                        break;
                    case 2:
                        students.Add(i, "Yana");
                        break;
                    case 3:
                        students.Add(i, "Fedor");
                        break;
                    case 4:
                        students.Add(i, "Oksana");
                        break;
                    case 5:
                        students.Add(i, "Andrey");
                        break;
                    case 6:
                        students.Add(i, "Katya");
                        break;
                }
            }

            for (int i = 1; i <= 300; i++)
            {
                var a = random.Next(1, 6);
                switch (a)
                {
                    case 1:
                        teachers.Add(i, "History");
                        break;
                    case 2:
                        teachers.Add(i, "Biology");
                        break;
                    case 3:
                        teachers.Add(i, "Sociology");
                        break;
                    case 4:
                        teachers.Add(i, "Mathematic");
                        break;
                    case 5:
                        teachers.Add(i, "English");
                        break;
                    case 6:
                        teachers.Add(i, "Philosopy");
                        break;
                }
            }


            //foreach (var item in students)
            //{
            //   Console.WriteLine($"{item.Key}\t{item.Value}");
            //}

            foreach (var item in teachers)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }

            string writePath = "dataStudents.sql";

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var item in students)
                {
                    sw.WriteLine($"INSERT INTO STUDENTS (ID, [NAME]) VALUES({item.Key},'{item.Value}');");

                }
                foreach (var item in teachers)
                {
                    sw.WriteLine($"INSERT INTO TEACHERS (ID, [FACULTATIES]) VALUES({item.Key},'{item.Value}');");

                }
                for (int i = 1; i <= 2000; i++)
                {
                    var b = random.Next(1, 2000);
                    var c = random.Next(1, 300);
                    sw.WriteLine($"INSERT INTO STUDENTS_TO_TEACHERS (ID_STUDENT,ID_TEACHER) VALUES({b},{c});");
                }
            }



            Console.Read();
        }
    }
}