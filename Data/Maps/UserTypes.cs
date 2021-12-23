using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public partial class UserTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserTypes()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public long ID_Role { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
