using System;
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
        public void AddNewUser(string fullName, string email, string login, string password, int id_role, long? group = null);
        public void AddTeachingGroup(UserDTO teacher, GroupDTO group);
        public void AddAttempt(QuizzeDTO quiz, int score, TimeSpan transitTime);
        public ObservableCollection<GroupDTO> GetListGroupTeacher();
        public ObservableCollection<AttemptDTO> GetListUserAttempt(UserDTO user);
        public ObservableCollection<AttemptDTO> GetListCurrentUserAttempt();
        public ObservableCollection<AttemptDTO> GetListCurrentUserAttempt(DateTime dateTime);
        public ObservableCollection<AttemptDTO> GetListTeacherAttempt();
        public ObservableCollection<AttemptDTO> GetListTeacherAttempt(DateTime dateTime);
        public ObservableCollection<QuizzeDTO> GetAppointmentQuizzes();
        public void RemoveUser(UserDTO user);
        public void SaveChange();
        public void Update(UserDTO user);
        public void Update(UserDTO user, string login, string password);
    }
}