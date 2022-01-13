using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Visual.View.Quiz.Form
{
    public class QuizViewModel
    {
        IQuizze quiz = Logic.Configuration.IocKernel.Get<IQuizze>();
        public QuizzeDTO CurrentQuiz;
        public QuestionDTO CurrentQuestion;
        public string CurIndex = "хуй";
        
        public QuizViewModel(long QuizID)
        {
            // получили текущий тест
            CurrentQuiz = quiz.GetEntity(QuizID);
            //CurrentQuestion = CurrentQuiz.Questions[CurIndex];

            //foreach (var question in CurrentQuizze.Questions)
            //{
            //    //ShowAnswers(question);
            //}
        }
        //public void ShowAnswers(QuestionDTO question)
        //{
        //    switch (CurrentQuestion.ID_QuestType)
        //    {
        //        case 0:
        //            foreach (var answ in CurrentQuestion.Answers)
        //            {
        //                RadioButton rb = new RadioButton { Content = answ.Text };
        //                stackPanel.Children.Add(rb);
        //            }
        //            break;
        //        case 1:
        //            foreach (var answ in CurrentQuestion.Answers)
        //            {
        //                CheckBox cb = new CheckBox { Content = answ.Text };
        //                stackPanel.Children.Add(cb);
        //            }
        //            break;
        //        default:
        //            TextBox tBox = new TextBox();
        //            stackPanel.Children.Add(tBox);
        //            break;
        //    }
        //}
    }
}
