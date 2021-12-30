using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface ISetTag
    {
        public SetTagDTO GetEntity(long id);
        public ObservableCollection<SetTagDTO> GetListEntity();
    }
}