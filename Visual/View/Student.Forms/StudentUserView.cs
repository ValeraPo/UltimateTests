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
        public IAppointmentQuizze appQ = Logic.Configuration.IocKernel.Get<IAppointmentQuizze>();
        IQuizze quiz = Logic.Configuration.IocKernel.Get<IQuizze>();
        IUser usI = Logic.Configuration.IocKernel.Get<IUser>();
        public IAttempt attemptI = Logic.Configuration.IocKernel.Get<IAttempt>();
        public ObservableCollection<AppointmentQuizzeDTO> appQuizzes;                                       //НАЗНАЧЕННЫЕ
        ObservableCollection<QuizzeDTO> quizzes;
        public ObservableCollection<AttemptDTO> attempts;                                                   // ПОПЫТКИ!
        QuizzeDTO SelectedQuiz;
        public UserDTO userDTO;
        int QuizCounter;
        long userID;
        public StudentUserView(UserDTO currentUserDTO)
        {

            attempts = usI.GetListUserAttempt(currentUserDTO);
            appQuizzes = usI.GetAppointmentQuizzes();
            quizzes = quiz.GetListEntity();            

        }

        
    }
}
