using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Maps
{
    public class TeachingGroup
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_User {get; set;}

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_Group {get; set;}

        public         bool  IsDel {get; set;}
        public virtual Group Group {get; set;}
        public virtual User  User  {get; set;}
    }
}