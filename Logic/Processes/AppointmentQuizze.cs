using System.Collections.ObjectModel;
using Data.Interfaces;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class AppointmentQuizze : IAppointmentQuizze
    {
        private IRepository<Data.Maps.AppointmentQuizze> _appointments;

        public AppointmentQuizze()
        {
            _appointments = IocKernel.Get<IRepository<Data.Maps.AppointmentQuizze>>();
        }

        public QuizzeDTO GetQuiz(AppointmentQuizzeDTO appo)
        {
            var tmp = _appointments.GetEntity(appo.Id);
            return new QuizzeDTO(tmp.Quizze);
        }
        public AppointmentQuizzeDTO GetEntity(long id)
        {
            return new AppointmentQuizzeDTO(_appointments.GetEntity(id));
        }
        public ObservableCollection<AppointmentQuizzeDTO> GetListEntity()
        {
            var appointments = new ObservableCollection<AppointmentQuizzeDTO>();
            foreach (var appointment in _appointments.GetListEntity())
                appointments.Add(new AppointmentQuizzeDTO(appointment));

            return appointments;
        }
        // Удаление назначения
        public void RemoveAppointment(AppointmentQuizzeDTO appointment)
        {
            _appointments.Delete(appointment.Id);
        }
        // Сохранить изменения
        public void SaveChange() => _appointments.Save();
        // Обновление модели (пересоздании зависимостей EF)
        public void Refresh() => _appointments.Refresh();
    }
}