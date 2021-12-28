using Data.Interfaces;

namespace Logic
{
    public static class Removing
    {
        // Удаление пользователя
        public static void RemoveUser(long id_user)
        {
            using IRepository<Data.Maps.User> users = new Data.Repositories.User();
            users.Delete(id_user);
        }
        // Удаление теста
        public static void RemoveQuizze(long id_quizze)
        {
            using IRepository<Data.Maps.Quizze> quizzes = new Data.Repositories.Quizze();
            quizzes.Delete(id_quizze);
        }
        // Удаление группы
        public static void RemoveGroup(long id_group)
        {
            using IRepository<Data.Maps.Group> groups = new Data.Repositories.Group();
            groups.Delete(id_group);
        }
        // Удаление тега
        public static void RemoveTeg(long id_teg)
        {
            using IRepository<Data.Maps.SetTag> tegs = new Data.Repositories.SetTag();
            tegs.Delete(id_teg);
        }
        
        // Удаление назначения
        public static void RemoveAppointment(long id_appointment)
        {
            using IRepository<Data.Maps.AppointmentQuizze> appointments = new Data.Repositories.AppointmentQuizze();
            appointments.Delete(id_appointment);
        }
        // Удаление фидбеков
        public static void RemoveFeedback(long id_feedback)
        {
            using IRepository<Data.Maps.Feedback> feedbacks = new Data.Repositories.Feedback();
            feedbacks.Delete(id_feedback);
        }
    }
}