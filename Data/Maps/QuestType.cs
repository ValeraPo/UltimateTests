using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Maps
{
    public class QuestType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestType()
        {
            Questions = new HashSet<Question>();
        }

        [Key] public int ID_QuestType {get; set;}

        [Column("QuestType")]
        [Required]
        [StringLength(20)]
        public string QuestType1 {get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions {get; set;}
    }
}