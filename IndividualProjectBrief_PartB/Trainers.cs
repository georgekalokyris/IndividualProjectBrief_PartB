//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndividualProjectBrief_PartB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trainers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainers()
        {
            this.CoursesTrainers = new HashSet<CoursesTrainers>();
        }
    
        public int TrainerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoursesTrainers> CoursesTrainers { get; set; }

        public override string ToString()
        {
            return ($"Trainer Id: {TrainerId}| FirstName: {FirstName}| LastName: {LastName}| Subject: {Subject}");
        }
    }
}