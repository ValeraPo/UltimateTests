using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public partial class Attempts
    {
        [Key]
        public long ID_Try { get; set; }

        public long ID_Quiz { get; set; }

        public long ID_User { get; set; }

        public int Score { get; set; }

        public TimeSpan TransitTime { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Quizes Quizes { get; set; }

        public virtual Users Users { get; set; }
    }
}
