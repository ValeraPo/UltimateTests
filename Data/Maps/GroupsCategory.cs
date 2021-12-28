using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Maps
{
    public class GroupsCategory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_Group { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_TagSet { get; set; }

        public bool IsDel { get; set; }

        public virtual Group Group { get; set; }

        public virtual SetTag SetTag { get; set; }
    }
}
