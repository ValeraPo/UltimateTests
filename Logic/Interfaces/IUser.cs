using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IUser
    {
        public UserDTO GetEntity(long id);
        public ObservableCollection<UserDTO> GetListEntity();
        public ObservableCollection<UserDTO> GetListStud();
        public ObservableCollection<UserDTO> GetListTeacher();
        public UserDTO Authorization(string login, string password);
        public void AddNewUser(string fullName, string email, string login, string password, int id_role, long? id_group = null);
        public void AddTeachingGroup(UserDTO teacher, GroupDTO group);
        public ObservableCollection<QuizzeDTO> GetAppointmentQuizzes();
        public void RemoveUser(UserDTO user);
        public void SaveChange();
        public void Update(UserDTO user);
        public void Update(UserDTO user, string login, string password);
    }
}