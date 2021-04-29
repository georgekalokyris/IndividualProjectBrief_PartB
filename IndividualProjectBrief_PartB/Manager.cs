using System;
using System.Linq;

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

                    var courses = Reader.GetAllCourses().Select(x => new SelectItem(x.CourseId, x.Title)).ToList(); ;



                    Console.WriteLine("Please select a course to assign the student to");

                    Main.Print(courses);

                    var courseid = Convert.ToInt32(Console.ReadLine());

                    CoursesStudents tocourse = new CoursesStudents()
                    {
                        CourseId = courseid,
                        StudentId = student.StudentId
                    };

                    Context.CoursesStudents.Add(tocourse);
                    Context.Students.Add(student);

                    var assignments = Context.Assignments.Select(x => new { x.AssignmentId, x.Title, x.Description, x.Courses })
                                            .Where(f => f.Courses.CourseId == courseid)
                                            .ToList();

                    var course = Reader.GetAllCourses().Where(f => f.CourseId == courseid).First();
                    Console.WriteLine("Press 1 to assign any assignment of the course to the student or x to continue");
                    Console.WriteLine($"Assignments of {course}");
                    Main.Print(assignments.Select(x => $"{x.AssignmentId}, {x.Title}"));


                    var opt = Console.ReadLine();


                    if (opt == "1")
                    {
                        bool more = true;
                        while (more)
                        {
                            Console.WriteLine("Please provide the id of the assignment, to assign to the student");
                            var assignmentid = int.Parse(Console.ReadLine());

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


                            Console.WriteLine("Press any button to continue adding assignments or x to return to the previous menu");

                            var x = Console.ReadLine();
                            if (x == "x")
                            {
                                break;
                            }
                            else continue;
                        }

                    }
                    else continue;


                    Context.SaveChanges();

                    Console.WriteLine("\nStudent added: ");
                    Console.WriteLine(student);
                    Console.WriteLine("to Course:");
                    Console.WriteLine(course);

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

                    Main.Print(coursesAndStudents.Select(x => new SelectItem(x.Key.CourseId, x.Key.Title)));

                    Console.WriteLine("Please enter the course's id for the assignment");

                    int courseId = Convert.ToInt32(Console.ReadLine());

                    var students = coursesAndStudents
                        .First(x => x.Key.CourseId == courseId)
                        .Value
                        .Select(x => new SelectItem(x.StudentId, $"{x.FirstName} {x.LastName}"));

                    Console.WriteLine("Students: ");

                    Main.Print(students);

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

                    Main.Print(courses);

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

                    Console.WriteLine("\nto Course: ");
                    Console.WriteLine(courses.First(c => c.Id == courseid));

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




    }


}


