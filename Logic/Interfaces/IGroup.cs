using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IGroup
    {
        public GroupDTO GetEntity(long id);
        public ObservableCollection<GroupDTO> GetListEntity();
    }
}