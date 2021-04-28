using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    public partial class Trainers
    {
        public override string ToString()
        {

            var builder = new StringBuilder();

            builder.AppendFormat($"Trainer Id: {TrainerId}");

            if (!string.IsNullOrEmpty(FirstName))
            {
                builder.AppendFormat($"|First Name: {FirstName}");
            }
            
            if (!string.IsNullOrEmpty(LastName))
            {
                builder.AppendFormat($"|Last Name: {LastName}");
            }

            if (!string.IsNullOrEmpty(Subject))
            {
                builder.AppendFormat($"|Subject: {Subject}");
            }

            return builder.ToString();

        }
    }
}
