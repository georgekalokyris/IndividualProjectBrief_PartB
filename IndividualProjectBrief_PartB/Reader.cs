using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace IndividualProjectBrief_PartB
{
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


}


