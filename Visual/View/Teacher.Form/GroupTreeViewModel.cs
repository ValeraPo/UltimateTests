using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.View.Teacher.Form
{
    internal class GroupTreeViewModel
    {
        public GroupTreeViewModel(GroupDTO group)
        {
            Students = GetStudentsByGroup(group);
            GroupsName = group.NameOfGroup;
        }

        ObservableCollection<UserDTO> GetStudentsByGroup(GroupDTO group)
        {
            ObservableCollection<UserDTO> students = new();
            foreach (var el in iUser.GetListStud())
            {
                if (el.Group == group.NameOfGroup)
                    students.Add(el);
            }
                return students;
        }
        public   string                        GroupsName { get; set; }
        public   ObservableCollection<UserDTO> Students   { get; set; }
        readonly IUser                         iUser = Logic.Configuration.IocKernel.Get<IUser>();
    }
}
