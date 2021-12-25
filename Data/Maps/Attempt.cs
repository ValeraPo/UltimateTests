using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Attempt
    {
        [Key]
        public long ID_Try { get; set; }

        public long ID_Quiz { get; set; }

        public long ID_User { get; set; }

        public int Score { get; set; }

        public TimeSpan TransitTime { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Quizze Quizze { get; set; }

        public virtual User User { get; set; }
    }
}
