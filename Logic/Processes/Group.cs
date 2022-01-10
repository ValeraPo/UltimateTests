using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
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
            if (myGroup.GroupsCategories.All(t => t.ID_TagSet != teg.Id))
            {
                 myGroup.GroupsCategories.Add(new GroupsCategory()
                                                         {
                                                             ID_Group  = group.Id,
                                                             ID_TagSet = teg.Id
                                                         });
            }
            else
                myGroup.GroupsCategories.Single(t => t.ID_TagSet == teg.Id).IsDel = false;

            _groups.Save();
        }
        //Выборка студентов по группе
        public ObservableCollection<UserDTO> GetListUser(GroupDTO group)
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in _groups.GetEntity(group.Id).Users)
                res.Add(new UserDTO(user));

            return res;
        }
        // Создание(добавление) группы
        public void AddGroup(string text)
        {
            if (_groups.GetListEntity()
                       .Select(t => t.NameOfGroup)
                       .Contains(text))
                throw new ArgumentException("Группа с таким названием уже существует");
            _groups.Create(new Data.Maps.Group()
                           {
                               NameOfGroup = text
                           });
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