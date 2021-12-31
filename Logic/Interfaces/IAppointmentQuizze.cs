using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IAppointmentQuizze
    {
        public AppointmentQuizzeDTO GetEntity(long id);
        public ObservableCollection<AppointmentQuizzeDTO> GetListEntity();
        public void RemoveAppointment(AppointmentQuizzeDTO appointment);
        public void SaveChange();
    }
}