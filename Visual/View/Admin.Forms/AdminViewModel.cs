using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Visual.View.Admin.Forms
{
    internal class AdminViewModel
    {
        readonly IGroup                         group = Logic.Configuration.IocKernel.Get<IGroup>();
        readonly IUser                          user  = Logic.Configuration.IocKernel.Get<IUser>();
        public   ObservableCollection<UserDTO>  StudentsList        { get; set; } //список всех студентов
        public   ObservableCollection<UserDTO>  CurrentStudentsList { get; set; } //список текущих студентов
        public   ObservableCollection<UserDTO>  TeachersList        { get; set; } //список всех преподов
        public   ObservableCollection<UserDTO>  CurrentTeachersList { get; set; } //текущие преподы
        public   ObservableCollection<UserDTO>  CurrentUsersList    { get; set; } //список текущих пользователей
        public   ObservableCollection<GroupDTO> GroupsList          { get; set; } //список всех групп
        

        public AdminViewModel()
        {
            GroupsList = group.GetListEntity();
            StudentsList = user.GetListStud();
            TeachersList = user.GetListTeacher();

            CurrentUsersList = StudentsList;
        }

        public void SelectStudents(GroupDTO selectedGroup)
        {
            CurrentUsersList = group.GetListUser(selectedGroup);
        }
        public void SelectTeachers(GroupDTO selectedGroup)
        {
            //CurrentTeachersList = (ObservableCollection<UserDTO>)TeachersList.Select(t => t.Group == selectedGroup.NameOfGroup);
            CurrentUsersList = group.GetListTeach(selectedGroup);
        }
    }
}
