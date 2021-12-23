using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Maps
{
    public partial class QuizzesCategories
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_Quiz { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_TagSet { get; set; }

        public bool IsDel { get; set; }

        public virtual Quizes Quizes { get; set; }

        public virtual SetTags SetTags { get; set; }
    }
}
