using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Quizze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quizze()
        {
            AppointmentQuizzes = new HashSet<AppointmentQuizze>();
            Attempts           = new HashSet<Attempt>();
            Feedbacks          = new HashSet<Feedback>();
            Questions          = new HashSet<Question>();
            QuizzesCategories  = new HashSet<QuizzesCategory>();
        }

        [Key] public                          long     ID_Quiz          {get; set;}
        public                                long     ID_UserCreateons {get; set;}
        [Required] [StringLength(280)] public string   Name             {get; set;}
        public                                TimeSpan TimeToComplete   {get; set;}
        public                                int      MaxPoints        {get; set;}
        public                                bool     IsDel            {get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentQuizze> AppointmentQuizzes {get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attempt> Attempts {get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks {get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions {get; set;}

        public virtual User User {get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuizzesCategory> QuizzesCategories {get; set;}
    }
}