using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Feedbacks
    {
        [Key]
        public long ID_Feedback { get; set; }

        public long ID_Quiz { get; set; }

        public long ID_User { get; set; }

        [Required]
        [StringLength(280)]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsDel { get; set; }

        public virtual Quizzes Quizzes { get; set; }

        public virtual Users Users { get; set; }
    }
}
