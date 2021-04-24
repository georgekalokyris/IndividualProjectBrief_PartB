using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    public partial class Courses
    {
        public override string ToString() //TODO: String builder formatting
        {
            return ($"Course Id: {CourseId}| Title: {Title}| Stream: {Stream}| Type: {Type}| Start Date: {Start_Date:d} | End Date: {End_Date}");
        }
    }
}
