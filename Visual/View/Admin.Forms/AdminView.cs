using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.View.Admin.Forms
{
    class AdminView
    {
        readonly         IGroup                        group = Logic.Configuration.IocKernel.Get<IGroup>();
        private readonly ObservableCollection<UserDTO> studentsList;
        private readonly ObservableCollection<UserDTO> usersList;
        private readonly ObservableCollection<UserDTO> teachersList;

        public IUser user = Logic.Configuration.IocKernel.Get<IUser>();
        public ObservableCollection<GroupDTO> GroupsList;
        public ObservableCollection<UserDTO> CurrentStudentsList;
        public ObservableCollection<UserDTO> CurrentTeachersList;

        public ObservableCollection<UserDTO> EmployersList;
        public ObservableCollection<UserDTO> CurrentEmployersList;
        public UserDTO SelectedUser;
        public AdminView()
        {
            GroupsList = group.GetListEntity();
            studentsList = user.GetListStud();
            usersList = user.GetListEntity();
            teachersList = user.GetListTeacher();
            EmployersList = GetListEmployers();
        }
        #region methods for find collections
        public ObservableCollection<UserDTO> GetListStudents(GroupDTO group)
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in studentsList.Where(t => t.Id == group.Id))
                res.Add(new UserDTO(user.Id, user.Type, user.FullName, user.Email, user.Group));
            return res;
        }
        public ObservableCollection<UserDTO> GetListTeachers(GroupDTO group)
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in teachersList.Where(t => t.Id == group.Id))
                res.Add(new UserDTO(user.Id, user.Type, user.FullName, user.Email, user.Group));
            return res;
        }
        public ObservableCollection<UserDTO> GetListEmployers()
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in usersList.Where(t => t.Id != 2))
                res.Add(new UserDTO(user.Id, user.Type, user.FullName, user.Email, user.Group));
            return res;
        }
        public ObservableCollection<UserDTO> GetCurrentEmployers(int id)
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in EmployersList.Where(t => t.Id == id))
                res.Add(new UserDTO(user.Id, user.Type, user.FullName, user.Email, user.Group));
            return res;
        }
        
        #endregion
        
        public static int GetIndexOfUserTypeByText(string text)
        {
            int userTypeIndex;
            if (text == "Студент")
            {
                userTypeIndex = 2;
            }
            else if (text == "Преподаватель")
            {
                userTypeIndex = 3;
            }
            else if (text == "Методист")
            {
                userTypeIndex = 4;
            }
            else
            {
                userTypeIndex = 1;
            }
            return userTypeIndex;
        }
    }
}
