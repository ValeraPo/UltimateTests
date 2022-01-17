using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Visual.View.Student.Forms
{
    internal class StudentUserView 
    {
        IAppointmentQuizze appQ = Logic.Configuration.IocKernel.Get<IAppointmentQuizze>();
        IQuizze quiz = Logic.Configuration.IocKernel.Get<IQuizze>();
        IUser usI = Logic.Configuration.IocKernel.Get<IUser>();
        public ObservableCollection<AppointmentQuizzeDTO> appQuizzes;
        ObservableCollection<QuizzeDTO> quizzes;
        public ObservableCollection<AttemptDTO> attempts;
        QuizzeDTO SelectedQuiz;
        public UserDTO userDTO;
        int QuizCounter;
        long userID;
        public StudentUserView(long QuizID=2)
        {
            userID = 1; //  удалить и добавить в конструктор
            userDTO = usI.GetEntity(userID);
            attempts = usI.GetListUserAttempt(userDTO);
            appQuizzes = appQ.GetListEntity();
            appQuizzes.Add(new AppointmentQuizzeDTO(1, DateTime.Now, "wtf"));
            quizzes = quiz.GetListEntity();
            SelectedQuiz = quiz.GetEntity(QuizID); // <- заменить параметр на выбранный

            attempts.Add(new AttemptDTO(55, 56, TimeSpan.MaxValue, DateTime.Now, "хз", userDTO.FullName));
        }

        
    }
}
