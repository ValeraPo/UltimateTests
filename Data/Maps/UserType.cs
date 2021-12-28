using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class UserType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserType()
        {
            Users = new HashSet<User>();
        }

        [Key]                         public int    ID_Role {get; set;}
        [Required] [StringLength(20)] public string Role    {get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users {get; set;}
    }
}