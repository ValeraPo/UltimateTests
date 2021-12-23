using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            AppointmentQuizzes = new HashSet<AppointmentQuizzes>();
            Attempts = new HashSet<Attempts>();
            Feedbacks = new HashSet<Feedbacks>();
            Quizzes = new HashSet<Quizzes>();
            TeachingGroups = new HashSet<TeachingGroups>();
        }

        [Key]
        public long ID_User { get; set; }

        public long? ID_Group { get; set; }

        public long ID_Role { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(33)]
        public string HashPass { get; set; }

        public bool IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentQuizzes> AppointmentQuizzes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attempts> Attempts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedbacks> Feedbacks { get; set; }

        public virtual Groups Groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quizzes> Quizzes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeachingGroups> TeachingGroups { get; set; }

        public virtual UserTypes UserTypes { get; set; }
    }
}
