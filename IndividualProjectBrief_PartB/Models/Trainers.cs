using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectBrief_PartB
{
    public partial class Trainers
    {
        public override string ToString() //TODO: String builder formatting
        {
            return ($"Trainer Id: {TrainerId}| FirstName: {FirstName}| LastName: {LastName}| Subject: {Subject}");
        }
    }
}
