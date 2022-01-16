using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IAttempt
    {
        public AttemptDTO GetEntity(long id);
        public ObservableCollection<AttemptDTO> GetListEntity();
        public void SaveChange();
        public void Refresh();
    }
}