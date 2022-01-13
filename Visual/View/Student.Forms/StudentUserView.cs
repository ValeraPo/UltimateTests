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
        ObservableCollection<AppointmentQuizzeDTO> appQuizzes;
        ObservableCollection<QuizzeDTO> quizzes;
        QuizzeDTO SelectedQuiz;
        int QuizCounter;
        public StudentUserView(long QuizID)
        {
            appQuizzes = appQ.GetListEntity();
            appQuizzes.Add(new AppointmentQuizzeDTO(1, DateTime.Now, "wtf"));
            quizzes = quiz.GetListEntity();
            SelectedQuiz = quiz.GetEntity(QuizID); // <- заменить параметр на выбранный
        }

        
    }
}
