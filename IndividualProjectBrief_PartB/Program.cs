using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    class Manager
    {
        public static void AddStudents() //TODO: Add Students
        {
            using (IndividualProjectBrief_Part_BEntities Context = new IndividualProjectBrief_Part_BEntities())
            {
                

            }
        }

        public static void AddCourses() //TODO: Add Courses
        {

        }

        public static void AddAssignments() //TODO: Add Assignments
        {

        }

        public static void AddTrainers() //TODO: Add Trainers
        {

        }

    }

    public class Reader
    {
        public static List<Students> GetAllStudents() //TODO: List all Students
        {
            using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
            {
                var students = dbContext.Students.ToList();
                return students;
            }
        }

        public static List<Courses> GetAllCourses() //TODO: List all Courses
        {
            using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
            {
                var courses = dbContext.Courses.ToList();
                return courses;
            }

        }
        public static List<Assignments> GetAllAssginments() //TODO: List all Assignments
        {
            using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
            {
                var assignments = dbContext.Assignments.ToList();
                return assignments;
            }

        }

        public static List<Trainers> GetAllTrainers() //TODO: List all Trainers
        {
            using (IndividualProjectBrief_Part_BEntities dbContext = new IndividualProjectBrief_Part_BEntities())
            {
                var trainers = dbContext.Trainers.ToList();
                return trainers;
            }

        }

    }

    class Printer
    {
        


    }

    class Program
    {
        
        static void Main(string[] args)
        {
            
            
            try
            {
                //foreach(var x in Reader.GetAllStudents())
                //{ 
                //    Console.WriteLine(x)
                //}

                foreach (var x in Reader.GetAllCourses())
                {
                    Console.WriteLine(x + "\n");
                }

                //foreach (var x in Reader.GetAllAssginments())
                //{
                //    Console.WriteLine(x);
                //}

                //foreach (var x in Reader.GetAllTrainers())
                //{
                //    Console.WriteLine(x);
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            


            //TODO: Menu with Reader/Editor options
            /* MENU ITEMS
             * Read Records
             * Insert Records
             * Delete Records
             */



        }
    }
}
