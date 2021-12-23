using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class SetTags
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SetTags()
        {
            GroupsCategories = new HashSet<GroupsCategories>();
            QuizzesCategories = new HashSet<QuizzesCategories>();
        }

        [Key]
        public long ID_TagSet { get; set; }

        [Required]
        [StringLength(20)]
        public string Text { get; set; }

        public bool IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupsCategories> GroupsCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuizzesCategories> QuizzesCategories { get; set; }
    }
}
