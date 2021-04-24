using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    public partial class Students
    {
        public override string ToString() //TODO: String builder formatting
        {
            return ($"Student ID: {StudentId}|FirstName: {FirstName}| Surname: {LastName}| Date Of Birth: {DateOfBirth}| TuitionFees: {TuitionFees:C}");
        }
    }
}
