using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IGroup
    {
        public GroupDTO GetEntity(long id);
        public ObservableCollection<GroupDTO> GetListEntity();
        public void AddTag(GroupDTO group, SetTagDTO teg);
        public void RemoveGroup(GroupDTO group);
        public void SaveChange();
        public void Update(GroupDTO group);
    }
}