using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    public partial class Assignments
    {

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendFormat("Assignment Title: {0}", Title);

            if (!string.IsNullOrWhiteSpace(Description))
            {
                builder.AppendFormat("| Description: {0}", Description);
            }

            builder.AppendFormat("| Submission Date: {0:d}", SubDateTime);

            if (OralMark.HasValue)
            {
                builder.AppendFormat("| OralMark: {0}", OralMark);
            }

            if (TotalMark.HasValue)
            {
                builder.AppendFormat("| TotalMark: {0}", TotalMark);
            }

            return builder.ToString();
        }

        
    }
}
