using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    public partial class Students
    {
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendFormat($"Student Id:{StudentId}");

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                builder.AppendFormat($"|First Name: {FirstName}");
            }

            if (!string.IsNullOrWhiteSpace(LastName))
            {
                builder.AppendFormat($"|Last Name: {LastName}");
            }

            if (DateOfBirth.HasValue)
            {
                builder.AppendFormat($"|Date of Birth: {DateOfBirth:d}");
            }

            if (TuitionFees.HasValue)
            {
                builder.AppendFormat($"|Tuition Fees: {TuitionFees:C}");
            }

            return builder.ToString();
        }
    }
}
