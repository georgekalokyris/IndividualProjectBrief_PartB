using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    public partial class Courses
    {
        public override string ToString() 
        {
            var builder = new StringBuilder();
         
            builder.AppendFormat($"Course Id: {CourseId}");

            if (!string.IsNullOrWhiteSpace(Title))
            {
                builder.AppendFormat($"| Title: {Title}");
            }

            if (!string.IsNullOrWhiteSpace(Stream))
            {
                builder.AppendFormat($"| Stream: {Stream}");
            }

            if (!string.IsNullOrWhiteSpace(Type))
            {
                builder.AppendFormat($"| Type: {Type}");
            }

            if (Start_Date.HasValue)
            {
                builder.AppendFormat($"| Start Date: {Start_Date:d}");
            }
            
            if (End_Date.HasValue)
            {
                builder.AppendFormat($"| End Date: {End_Date:d}");
            }


            return builder.ToString();
        
        
        
        
        
        }
    }
}
