using System;
using System.Collections.ObjectModel;
using Data.Interfaces;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class AppointmentQuizze : IAppointmentQuizze
    {
        private IRepository<Data.Maps.AppointmentQuizze> _appointments;

        public AppointmentQuizze(IRepository<Data.Maps.AppointmentQuizze> appointments)
        {
            _appointments = appointments;
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
    }
}