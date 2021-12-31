using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data.Interfaces;
using Data.Maps;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class Group : IGroup
    {
        private IRepository<Data.Maps.Group> _groups;

        public Group()
        {
            _groups = IocKernel.Get<IRepository<Data.Maps.Group>>();
        }


        public GroupDTO GetEntity(long id)
        {
            return new GroupDTO(_groups.GetEntity(id));
        }
        public ObservableCollection<GroupDTO> GetListEntity()
        {
            var groups = new ObservableCollection<GroupDTO>();
            foreach (var group in _groups.GetListEntity()) { groups.Add(new GroupDTO(group)); }

            return groups;
        }
        //Добавить тег группе
        public void AddTag(GroupDTO group, SetTagDTO teg)
        {
            var myGroup = _groups.GetEntity(group.Id);
            myGroup.GroupsCategories.Add(new GroupsCategory()
                                         {
                                             ID_Group  = group.Id,
                                             ID_TagSet = teg.Id
                                         });

            _groups.Save();
        }
        // Удаление группы
        public void RemoveGroup(GroupDTO group)
        {
            _groups.Delete(group.Id);
        }
        // Сохранить изменения
        public void SaveChange() => _groups.Save();
        //Сохранение изменения
        public void Update(GroupDTO group)
        {
            var tmp = _groups.GetEntity(group.Id);
            tmp.NameOfGroup = group.NameOfGroup;
            _groups.Update(tmp);

            SaveChange();
        }
    }
}