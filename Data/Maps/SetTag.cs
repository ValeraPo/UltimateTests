using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class SetTag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SetTag()
        {
            GroupsCategories = new HashSet<GroupsCategory>();
            QuizzesCategories = new HashSet<QuizzesCategory>();
        }

        [Key]
        public long ID_TagSet { get; set; }

        [Required]
        [StringLength(20)]
        public string Text { get; set; }

        public bool IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupsCategory> GroupsCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuizzesCategory> QuizzesCategories { get; set; }
    }
}
