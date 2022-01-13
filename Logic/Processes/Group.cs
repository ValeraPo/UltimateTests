using System;
using System.Collections.Generic;
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
        public GroupDTO GetEntity(string name)
        {
            return new GroupDTO(_groups.GetListEntity().Single(t=>t.NameOfGroup == name));
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

        #region UsersByGrop

        //Выборка по группе
        private ObservableCollection<UserDTO> GetListPeople(IEnumerable<Data.Maps.User> collection)
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in collection)
                res.Add(new UserDTO(user));

            return res;
        }
        //Выборка преподавателей по группе
        public ObservableCollection<UserDTO> GetListTeach(GroupDTO group)
        {
            return GetListPeople(_groups.GetEntity(group.Id).TeachingGroups.Select(t => t.User));
        }
        //Выборка студентов по группе
        public ObservableCollection<UserDTO> GetListUser(GroupDTO group)
        {
            return GetListPeople(_groups.GetEntity(group.Id).Users); 
        }

        #endregion
        
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
            SaveChange();
        }
        // Удаление группы
        public void RemoveGroup(GroupDTO group)
        {
            _groups.Delete(group.Id);
        }
        public void RemoveGroup(string name)
        {
            _groups.Delete(_groups.GetListEntity().Single(t=> t.NameOfGroup == name).ID_Group);
        }
        // Сохранить изменения
        public void SaveChange() => _groups.Save();
        //Сохранение изменения
        public void Update(GroupDTO group)
        {
            var tmp = _groups.GetEntity(group.Id);
            if (_groups.GetListEntity()
                       .Select(t => t.NameOfGroup)
                       .Contains(group.NameOfGroup))
                throw new ArgumentException("Группа с таким названием уже существует");
            tmp.NameOfGroup = group.NameOfGroup;
            _groups.Update(tmp);

            SaveChange();
        }
    }
}