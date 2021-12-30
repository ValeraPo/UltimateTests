using System;

namespace Logic.DTO
{
    public class AppointmentQuizzeDTO
    {
        public AppointmentQuizzeDTO(long id, DateTime finishBefore, string nameQuiz)
        {
            Id           = id;
            FinishBefore = finishBefore;
            NameQuiz     = nameQuiz;
        }
        public AppointmentQuizzeDTO(Data.Maps.AppointmentQuizze appointment)
        {
            Id           = appointment.ID_Appointment;
            FinishBefore = appointment.FinishBefore;
            NameQuiz     = appointment.Quizze.Name;
        }


        public long     Id           {get; set;}
        public DateTime FinishBefore {get; set;}
        public string   NameQuiz     {get; set;}
    }
}