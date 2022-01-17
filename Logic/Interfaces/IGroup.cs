using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IGroup
    {
        public GroupDTO GetEntity(long id);
        public GroupDTO GetEntity(string name);
        public ObservableCollection<GroupDTO> GetListEntity();
        public void AddTag(GroupDTO group, SetTagDTO teg);
        public ObservableCollection<SetTagDTO> GetListTags(GroupDTO group);
        public ObservableCollection<UserDTO> GetListTeach(GroupDTO group);
        public ObservableCollection<UserDTO> GetListUser(GroupDTO group);
        public void AddGroup(string text);
        public void RemoveGroup(GroupDTO group);
        public void RemoveGroup(string name);
        public void SaveChange();
        public void Refresh();
        public void Update(GroupDTO group);
    }
}