using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Attempts
    {
        [Key]
        public long ID_Try { get; set; }

        public long ID_Quiz { get; set; }

        public long ID_User { get; set; }

        public int Score { get; set; }

        public TimeSpan TransitTime { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Quizzes Quizzes { get; set; }

        public virtual Users Users { get; set; }
    }
}
