using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        [Key]
        public long ID_Quest { get; set; }

        public long ID_Quiz { get; set; }

        public int ID_QuestType { get; set; }

        [Required]
        [StringLength(280)]
        public string Text { get; set; }

        public bool IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual QuestType QuestType { get; set; }

        public virtual Quizze Quizze { get; set; }
    }
}
