using IndividualProjectBrief_PartB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

namespace IndividualProjectBrief_PartB
{
    class Manager
    {

        public static void AddStudents() //TODO: Add Students to Courses
        {
            using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
            {

                bool ContS = true;
                while (ContS)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("---------Adding Students---------");
                    Console.WriteLine("\nPlease enter the student's first name");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Please enter the student's last name");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Please enter the student's dateOfBirth");
                    DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Please enter the amount of the total tuitionFees");
                    int fees = int.Parse(Console.ReadLine());

                    Students student = new Students()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        TuitionFees = fees
                    };

                    Context.Students.Add(student);
                    Context.SaveChanges();

                    Console.WriteLine("\nRecord added: ");
                    Console.WriteLine(student);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\n\nPress enter to continue adding records or 'x' to return to the top menu");

                    if (Console.ReadLine() == "x")
                    {
                        ContS = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }


        public static void AddCourses()
        {
            using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
            {

                bool ContC = true;
                while (ContC)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("---------Adding Courses---------");

                    Console.WriteLine("Please enter the title of the Course");
                    string title = Console.ReadLine();

                    Console.WriteLine("Please enter the stream of the Course");
                    string stream = Console.ReadLine();

                    Console.WriteLine("Please enter the type of the Course");
                    string type = Console.ReadLine();

                    Console.WriteLine("Please enter the course's starting date");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Please enter the course's end date");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                    Courses newcourse = new Courses()
                    {
                        Title = title,
                        Stream = stream,
                        Type = type,
                        Start_Date = startDate,
                        End_Date = endDate
                    };

                    Context.Courses.Add(newcourse);
                    Context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nRecord added: ");
                    Console.WriteLine(newcourse);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\n\nPress enter to continue adding records or 'x' to return to the top menu");
                    Console.ResetColor();

                    if (Console.ReadLine() == "x")
                    {
                        ContC = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
        }


        public static void AddAssignments()
        {
            using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
            {
                bool ContA = true;
                while (ContA)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("---------Adding Assignments---------");
                    Console.WriteLine("Please enter the title of the Assignment");
                    string title = Console.ReadLine();

                    Console.WriteLine("Please enter the description of the Assignment");
                    string description = Console.ReadLine();

                    Console.WriteLine("Please enter the Assignment's final submission date");
                    DateTime subDateTime = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Please enter the Assignment's oral mark");
                    int oralMark = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please enter the Assignment's total mark");
                    int totalMark = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Courses: ");

                    var coursesAndStudents = Reader.GetAllStudentsPerCourse();
                    
                    Program.Print(coursesAndStudents.Select(x => new SelectItem(x.Key.CourseId, x.Key.Title)));

                    Console.WriteLine("Please enter the course's id for the assignment");

                    int courseId = Convert.ToInt32(Console.ReadLine());

                    var students = coursesAndStudents
                        .First(x => x.Key.CourseId == courseId)
                        .Value
                        .Select(x => new SelectItem(x.StudentId, $"{x.FirstName} {x.LastName}"));

                    Console.WriteLine("Students: ");

                    Program.Print(students);

                    Console.WriteLine("Please enter the student's id for the assignment");
                    
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    Assignments assignment = new Assignments()
                    {
                        Title = title,
                        Description = description,
                        SubDateTime = subDateTime,
                        OralMark = oralMark,
                        TotalMark = totalMark,
                        CourseId = courseId,
                        StudentId = studentId,
                    };

                    Context.Assignments.Add(assignment);
                    Context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nRecord added: ");
                    Console.WriteLine(assignment);


                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\n\nPress enter to continue adding records or 'x' to return to the top menu");
                    Console.ResetColor();

                    if (Console.ReadLine() == "x")
                    {
                        ContA = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
        }


        public static void AddTrainers() 
        {
            using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
            {               
                bool ContT = true;
                while (ContT)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("---------Adding Trainers---------");

                    Console.WriteLine("Please enter the trainer's first name");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Please enter the trainer's last name");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Please enter the trainer's subject");
                    string subject = Console.ReadLine();

                    Trainers trainer = new Trainers()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Subject = subject
                    };


                    var courses = Reader.GetAllCourses().Select(x => new SelectItem(x.CourseId, x.Title));

                    Program.Print(courses);

                    Console.WriteLine($"Please select the id of the course to assign trainer with name [{firstName} {lastName}] to");

                    var courseid = (Convert.ToInt32(Console.ReadLine()));

                    var trainerid = trainer.TrainerId;

                    CoursesTrainers ct = new CoursesTrainers()
                    {
                        CourseId = courseid,
                        TrainerId = trainerid
                    };


                    Context.Trainers.Add(trainer);
                    Context.CoursesTrainers.Add(ct);
                    
                    Context.SaveChanges();

                    Console.WriteLine("\nTrainer added: ");
                    Console.WriteLine(trainer);

                    Console.WriteLine("\nto course: ");
                    Console.WriteLine(courses.First(c=>c.Id == courseid));

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\n\nPress enter to continue adding records or 'x' to return to the top menu");

                    if (Console.ReadLine() == "x")
                    {
                        ContT = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public class Reader
        {
            public static IEnumerable<Students> GetAllStudents()
            {               
                using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
                {
                    return dbContext.Students.ToList();
                }
            }


            public static IEnumerable<Courses> GetAllCourses()
            {
                using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
                {
                    return dbContext.Courses.ToList();
                }

            }
            public static IEnumerable<Assignments> GetAllAssignments()
            {
                using (var ctx = new IndividualProjectBrief_Part_BEntities())
                {
                    return ctx.Assignments.Select(x => new { x.Title, x.Description }).Distinct().ToList()
                        .Select(x => new Assignments { Title = x.Title, Description = x.Description }); 
                }
            }

            public static IEnumerable<Trainers> GetAllTrainers()
            {
                using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
                {
                    return dbContext.Trainers.ToList();
                }

            }

            public static IDictionary<Courses, IEnumerable<Students>> GetAllStudentsPerCourse()
            {
                using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
                {
                    return dbContext.Courses.Include(x => x.CoursesStudents.Select(f => f.Students)).Where(x => x.CoursesStudents.Any()).ToDictionary(x => x, x => x.CoursesStudents.Select(f => f.Students));

                }
            }

            public static IDictionary<Courses, IEnumerable<Trainers>> GetAllTrainersPerCourse()
            {
                using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
                {

                    return dbContext.Courses.Include(x => x.CoursesTrainers.Select(f => f.Trainers)).Where(x => x.CoursesTrainers.Any()).ToDictionary(x => x, x => x.CoursesTrainers.Select(f => f.Trainers));
                }
            }

            public static IDictionary<Courses, IEnumerable<Assignments>> GetAllAssginmentsPerCourse()
            {
                using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
                {
                    var dictionary = new Dictionary<Courses, IEnumerable<Assignments>>();

                    var assignments = Context.Assignments.Select(x => new { x.Title, x.Description, x.Courses })
                        .Distinct()
                        .ToList()
                        .Select(x => new Assignments { Title = x.Title, Description = x.Description, Courses = x.Courses });

                    foreach (var assignment in assignments)
                    {
                        if (dictionary.ContainsKey(assignment.Courses))
                        {
                            var list = dictionary[assignment.Courses].ToList();
                            list.Add(assignment);
                            
                            dictionary[assignment.Courses] = list;
                        }
                        else 
                        {
                            dictionary.Add(assignment.Courses, new Assignments[] { assignment });
                        }
                    }

                    return dictionary;
                }
            }

            public static IDictionary<Students, IDictionary<Courses, IEnumerable<Assignments>>> GetAllAssignmentsPerStudentPerCourse()
            {
                using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
                {
                    var dictionary = new Dictionary<Students, IDictionary<Courses, IEnumerable<Assignments>>>();

                    var assignments = Context.Assignments.ToList();

                    foreach (var assignment in assignments)
                    {
                        IDictionary<Courses, IEnumerable<Assignments>> innerDictionary;

                        if (dictionary.ContainsKey(assignment.Students))
                        {
                            innerDictionary = dictionary[assignment.Students];
                        }
                        else
                        {
                            innerDictionary = new Dictionary<Courses, IEnumerable<Assignments>>();
                            dictionary.Add(assignment.Students, innerDictionary);
                        }

                        if (innerDictionary.ContainsKey(assignment.Courses))
                        {
                            var list = innerDictionary[assignment.Courses].ToList();
                            list.Add(assignment);

                            innerDictionary[assignment.Courses] = list;
                        }
                        else
                        {
                            innerDictionary.Add(assignment.Courses, new Assignments[] { assignment });
                        }
                    }

                    return dictionary;
                }
            }

            public static IEnumerable<Students> GetStudentsInMoreThanOneCourse() 
            {
                using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
                {
                    return Context.Students.Where(x => x.CoursesStudents.Count > 1).ToList();
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {

                try
                {

                    Run();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            public static void Run()
            {
                

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Welcome to Peoplecert's Student System");
                Console.ResetColor();

                bool ContM = true;
                while (ContM)
                {

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

                Console.WriteLine("Option '2' Selected - Manual Data Input");
                bool ContM2 = true;
                while (ContM2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;


                    Console.WriteLine("Please select the table that you would like to populate");
                    Console.WriteLine("Press 1 for Students");
                    Console.WriteLine("Press 2 for Courses");
                    Console.WriteLine("Press 3 for Assignments");
                    Console.WriteLine("Press 4 for Trainers");
                    Console.WriteLine("Press x to return to the Main Menu");
                    Console.ResetColor();


                    switch (Console.ReadLine())
                    {
                        case "1":
                            AddStudents();
                            ContM2 = true;
                            continue;
                        case "2":
                            AddCourses();
                            ContM2 = true;
                            continue;
                        case "3":
                            AddAssignments();
                            ContM2 = true;
                            continue;
                        case "4":
                            AddTrainers();
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
                bool ContPres = true;
                while (ContPres)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Press 1 to view all of the student records");
                    Console.WriteLine("Press 2 to view all of the trainer records");
                    Console.WriteLine("Press 3 to view all of the assignments records");
                    Console.WriteLine("Press 4 to view all of the course records");
                    Console.WriteLine("Press 5 to view all of the students per course");
                    Console.WriteLine("Press 6 to view all of the trainers per course");
                    Console.WriteLine("Press 7 to view all of the assignments per course");
                    Console.WriteLine("Press 8 to view all of the assignments per course per student");
                    Console.WriteLine("Press 9 to view all of the students that belong in more than one course");

                    Console.WriteLine("Press x to return to the previous menu");
                    Console.ResetColor();

                    switch (Console.ReadLine())
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
                        Console.WriteLine(key);

                        Print(dictionary[key]);
                    }                    
                }
                else if (obj is IEnumerable)
                {
                    foreach (var item in ((IEnumerable)obj))
                    {
                        Console.WriteLine(item);
                    }
                }
                else 
                {
                    Console.WriteLine(obj);
                }
                Console.WriteLine();
            }
        }
    }

    class SelectItem
    {
        public SelectItem(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{Id} - {Value}";
        }
    }


}


