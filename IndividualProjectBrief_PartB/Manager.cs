using System;
using System.Linq;

namespace IndividualProjectBrief_PartB
{
    class Manager
    {
        public static void AddStudents() //Creates new Students and allocates them to a Course and to the Assignments of the course
        {
            using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
            {

                bool ContS = true;
                while (ContS)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("-------------Adding Students-------------");

                    Main.PrintLine(40, ".");
                    Console.WriteLine("\nPlease enter the student's first name");
                    string firstName = Console.ReadLine();

                    Main.PrintLine(40, ".");
                    Console.WriteLine("\nPlease enter the student's last name");
                    string lastName = Console.ReadLine();
                    
                    Main.PrintLine(40, ".");
                    Console.WriteLine("\nPlease enter the student's dateOfBirth");
                    DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                    Main.PrintLine(40, ".");
                    Console.WriteLine("\nPlease enter the amount of the total tuitionFees");
                    int fees = int.Parse(Console.ReadLine());
                    
                    Main.PrintLine(40, ".");
                    Students student = new Students()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        TuitionFees = fees
                    };

                    var courses = Reader.GetAllCourses().Select(x => new SelectItem(x.CourseId, x.Title)).ToList();

                    //Assign a course to the student
                    Console.WriteLine("\nActive courses:");
                    Main.PrintLine(40, ".");

                    Main.Print(courses);
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease select the id of the course to assign the student to");
                    var courseid = Convert.ToInt32(Console.ReadLine());
                    Main.PrintLine(40, ".");
                    Console.WriteLine();
                    CoursesStudents tocourse = new CoursesStudents()
                    {
                        CourseId = courseid,
                        StudentId = student.StudentId
                    };

                    Context.CoursesStudents.Add(tocourse);
                    Context.Students.Add(student);

                    var course = Reader.GetAllCourses().Where(f => f.CourseId == courseid).First();
                    Console.WriteLine($"Assignments of {course}");
                    Main.PrintLine(40, ".");


                    var assignments = Context.Assignments.Select(x => new { x.AssignmentId, x.Title, x.Description, x.Courses })
                                            .Where(f => f.Courses.CourseId == courseid)
                                            .ToList();
                    Main.Print(assignments.Select(x => $"{x.AssignmentId}, {x.Title}"));
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPress 'y' to assign any assignment of the course to the student or 'n' to bypass this option");

                    var opt = Console.ReadLine();
                    Main.PrintLine(40, ".");


                    if (opt == "y")
                    {
                        bool more = true;
                        while (more)
                        {
                            Console.WriteLine("\nPlease provide the id of the assignment, to assign to the student");
                            var assignmentid = int.Parse(Console.ReadLine());
                            Main.PrintLine(40, ".");

                            var assignmentTitle = Context.Assignments.FirstOrDefault(c => c.AssignmentId == assignmentid).Title;

                            var assignmentDescription = Context.Assignments.FirstOrDefault(c => c.AssignmentId == assignmentid).Description;

                            var assignmentSubDate = Context.Assignments.FirstOrDefault(c => c.AssignmentId == assignmentid).SubDateTime;

                            var assignmentOralMark = Context.Assignments.FirstOrDefault(c => c.AssignmentId == assignmentid).OralMark;

                            var assignmentTotalMark = Context.Assignments.FirstOrDefault(c => c.AssignmentId == assignmentid).TotalMark;

                            var cs = new Assignments
                            {
                                Title = assignmentTitle,
                                Description = assignmentDescription,
                                SubDateTime = assignmentSubDate,
                                OralMark = assignmentOralMark,
                                TotalMark = assignmentTotalMark,
                                CourseId = courseid,
                                StudentId = student.StudentId
                            };

                            Context.Assignments.Add(cs);


                            Console.WriteLine("\nPress any button to continue adding assignments or x to return to the previous menu");

                            var x = Console.ReadLine();
                            Main.PrintLine(40, ".");

                            if (x == "x")
                            {
                                break;
                            }
                            else continue;
                        }

                    }
                    


                    Context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nStudent added:");
                    Console.WriteLine(student);
                    Console.WriteLine("to Course:");
                    Console.WriteLine(course);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Main.PrintLine(40, ".");
                    
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
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the title of the Course");
                    string title = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the stream of the Course");
                    string stream = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the type of the Course");
                    string type = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the course's starting date");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the course's end date");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                    Main.PrintLine(40, ".");

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
                    Main.PrintLine(newcourse.ToString().Length, ".");

                    Console.ForegroundColor = ConsoleColor.Green;


                    Console.WriteLine("\n\nPress enter to continue adding records or 'x' to return to the top menu");


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
        } //Creates new Courses

        public static void AddAssignments() //Creates new Assignments and associates them with a Course and Student
        {
            using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
            {
                bool ContA = true;
                while (ContA)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("---------Adding Assignments---------");
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the title of the Assignment");
                    string title = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the description of the Assignment");
                    string description = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the Assignment's final submission date");
                    DateTime subDateTime = Convert.ToDateTime(Console.ReadLine());
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the Assignment's oral mark");
                    int oralMark = Convert.ToInt32(Console.ReadLine());
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the Assignment's total mark");
                    int totalMark = Convert.ToInt32(Console.ReadLine());
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nActive Courses:");
                    var coursesAndStudents = Reader.GetAllStudentsPerCourse();
                    Main.PrintLine(40, ".");
                    Console.WriteLine();
                    Main.Print(coursesAndStudents.Select(x => new SelectItem(x.Key.CourseId, x.Key.Title)));
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the course's id for the assignment");

                    int courseId = Convert.ToInt32(Console.ReadLine());
                    Main.PrintLine(40, ".");

                    var students = coursesAndStudents
                        .First(x => x.Key.CourseId == courseId)
                        .Value
                        .Select(x => new SelectItem(x.StudentId, $"{x.FirstName} {x.LastName}"));

                    Console.WriteLine("\nActive Students in selected course: ");
                    Main.PrintLine(40, ".");

                    Main.Print(students);

                    Console.WriteLine("\nPlease enter the student's id for the assignment");

                    int studentId = Convert.ToInt32(Console.ReadLine());
                    Main.PrintLine(40, ".");

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

                    Console.WriteLine("\nAssignment added:");
                    Console.WriteLine(assignment);
                    Console.WriteLine("to Student:");
                    Console.WriteLine(Context.Students.FirstOrDefault(x => x.StudentId == studentId));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Main.PrintLine(40, ".");

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
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the trainer's first name");
                    string firstName = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the trainer's last name");
                    string lastName = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Console.WriteLine("\nPlease enter the trainer's subject");
                    string subject = Console.ReadLine();
                    Main.PrintLine(40, ".");

                    Trainers trainer = new Trainers()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Subject = subject
                    };

                    var courses = Reader.GetAllCourses().Select(x => new SelectItem(x.CourseId, x.Title));
                    Main.PrintLine(40, ".");

                    Main.Print(courses);

                    Console.WriteLine($"\nPlease select the id of the course to assign the trainer with name [{firstName} {lastName}] to");

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

                    Main.PrintLine(40, ".");
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nTrainer added: ");
                    Console.WriteLine(trainer);

                    Console.WriteLine("to Course: ");
                    Console.WriteLine(courses.First(c => c.Id == courseid));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Main.PrintLine(40, ".");

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
        } //Creates new Trainers and allocates them to a Course
    }
}


