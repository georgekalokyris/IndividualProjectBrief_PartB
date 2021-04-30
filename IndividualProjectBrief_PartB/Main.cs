using System;
using System.Collections;

namespace IndividualProjectBrief_PartB
{
    public class Main
    {
        //TODO: Add comments everywhere
        //TODO: Clear database
        public static void Run()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Peoplecert's Student System");
            Console.ResetColor();

            bool ContM = true;
            while (ContM)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nMain Menu");

                Console.ForegroundColor = ConsoleColor.Yellow;

                //Top Menu
                Console.WriteLine("\nPlease Select an option to continue");
                Console.WriteLine("\nPress 1 for Data Presentation");
                Console.WriteLine("\nPress 2 for Data Manipulation");
                Console.WriteLine("\nPress x key to exit");



                switch (Console.ReadLine())
                {
                    case "1":
                        DataPresentation();
                        break;
                    case "2":
                        DataManipulation();
                        break;
                    case "x":
                        Console.WriteLine("Thank you for using the Student System");
                        ContM = false;
                        break;
                    default:
                        continue;
                }
                Console.ResetColor();
            }
        }

        private static void DataManipulation() 
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nOption '2' Selected - Manual Data Input");
            bool ContM2 = true;
            while (ContM2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;


                Console.WriteLine("\nPlease select the table that you would like to populate");
                Console.WriteLine("\nPress 1 for Students");
                Console.WriteLine("Press 2 for Courses");
                Console.WriteLine("Press 3 for Assignments");
                Console.WriteLine("Press 4 for Trainers");
                Console.WriteLine("Press x to return to the Main Menu");


                switch (Console.ReadLine())
                {
                    case "1":
                        Manager.AddStudents();
                        ContM2 = true;
                        continue;
                    case "2":
                        Manager.AddCourses();
                        ContM2 = true;
                        continue;
                    case "3":
                        Manager.AddAssignments();
                        ContM2 = true;
                        continue;
                    case "4":
                        Manager.AddTrainers();
                        ContM2 = true;
                        continue;
                    case "x":
                        ContM2 = false;
                        break;
                    default:
                        continue;
                }
            }
        }

        public static void DataPresentation()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nOption '1' Selected - Data Presentation");
            bool ContPres = true;
            while (ContPres)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\nPress 1 to view all of the student records");
                Console.WriteLine("Press 2 to view all of the trainer records");
                Console.WriteLine("Press 3 to view all of the assignments records");
                Console.WriteLine("Press 4 to view all of the course records");
                Console.WriteLine("Press 5 to view all of the students per course");
                Console.WriteLine("Press 6 to view all of the trainers per course");
                Console.WriteLine("Press 7 to view all of the assignments per course");
                Console.WriteLine("Press 8 to view all of the assignments per course per student");
                Console.WriteLine("Press 9 to view all of the students that belong in more than one course");
                Console.WriteLine("Press x to return to the previous menu");

                var opt = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;

                switch (opt)
                {   
                    case "1":
                        Print(Reader.GetAllStudents());
                        break;
                    case "2":
                        Print(Reader.GetAllTrainers());
                        break;
                    case "3":
                        Print(Reader.GetAllAssignments());
                        break;
                    case "4":
                        Print(Reader.GetAllCourses());
                        break;
                    case "5":
                        Print(Reader.GetAllStudentsPerCourse());
                        break;
                    case "6":
                        Print(Reader.GetAllTrainersPerCourse());
                        break;
                    case "7":
                        Print(Reader.GetAllAssginmentsPerCourse());
                        break;
                    case "8":
                        Print(Reader.GetAllAssignmentsPerStudentPerCourse());
                        break;
                    case "9":
                        Print(Reader.GetStudentsInMoreThanOneCourse());
                        break;
                    case "x":
                        ContPres = false;
                        break;

                }


            }
        }

        public static void Print(object obj, string s = null)
        {
            if (obj is IDictionary)
            {
                var dictionary = ((IDictionary)obj);
                foreach (var key in dictionary.Keys)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n{key}");
                    PrintLine(key.ToString().Length,"~");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Print(dictionary[key]);
                    

                }
            }
            else if (obj is IEnumerable)
            {
                foreach (var item in ((IEnumerable)obj))
                {
                    Console.WriteLine($"\n{item}");
                    PrintLine(item.ToString().Length,"-");
                     
                }
            }
            else
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        public static void PrintLine(int x, string sym)
        {
            for (int i= 0; i <= x; i++)
            {
                Console.Write($"{sym}");
            }
        }

    }

}


