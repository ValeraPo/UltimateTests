using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class AppointmentQuizze
    {
        [Key]
        public long ID_Appointment { get; set; }

        public long ID_Quiz { get; set; }

        public long ID_User { get; set; }

        public DateTime FinishBefore { get; set; }

        public bool IsDel { get; set; }

        public virtual Quizze Quizze { get; set; }

        public virtual User User { get; set; }
    }
}
