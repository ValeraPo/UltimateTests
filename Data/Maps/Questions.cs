using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Questions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questions()
        {
            Answers = new HashSet<Answers>();
        }

        [Key]
        public long ID_Quest { get; set; }

        public long ID_Quiz { get; set; }

        [Required]
        [StringLength(280)]
        public string Text { get; set; }

        public bool IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answers> Answers { get; set; }

        public virtual Quizzes Quizzes { get; set; }
    }
}
