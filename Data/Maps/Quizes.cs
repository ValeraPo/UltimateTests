using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public partial class Quizes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quizes()
        {
            AppointmentQuizes = new HashSet<AppointmentQuizes>();
            Attempts = new HashSet<Attempts>();
            Feedbacks = new HashSet<Feedbacks>();
            Questions = new HashSet<Questions>();
            QuizzesCategories = new HashSet<QuizzesCategories>();
        }

        [Key]
        public long ID_Quiz { get; set; }

        public long ID_UserCreateons { get; set; }

        public TimeSpan TimeToComplete { get; set; }

        public int MaxPoints { get; set; }

        public bool IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentQuizes> AppointmentQuizes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attempts> Attempts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedbacks> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questions> Questions { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuizzesCategories> QuizzesCategories { get; set; }
    }
}
