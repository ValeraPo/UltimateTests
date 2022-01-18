using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Visual.View.Quiz.Form
{
    public partial class QuizWindow : Window
    {
        QuizzeDTO currentQuiz;
        IQuizze quiz = Logic.Configuration.IocKernel.Get<IQuizze>();
        int CounterQuiz;
        string _currentQuestinsInfo;

        //ctor
        public QuizWindow(long QuizID, bool TetsTry = false)
        {
            InitializeComponent();
            currentQuiz = quiz.GetEntity(QuizID);
            CounterQuiz = 0;
            RefreshAnswerField();
        }
        public void RefreshAnswerField()
        {
            stackPanel.Children.Clear();
            _currentQuestinsInfo = $"Вопрос №{CounterQuiz + 1} из {currentQuiz.Questions.Count}"; // вытащить в отдельный метод
            QuestionInfoTextBlock.Text = _currentQuestinsInfo;                                    // вытащить в отдельный метод
            QuestionTextBlock.Text = currentQuiz.Questions[CounterQuiz].Text;
            SetAnswers();
        }
        private void SetAnswers()
        {
            switch (currentQuiz.Questions[CounterQuiz].ID_QuestType)
            {
                case 1:
                    foreach (var answ in currentQuiz.Questions[CounterQuiz].Answers)
                        stackPanel.Children.Add(new RadioButton()
                        {
                            Content = answ.Text,
                        });
                    break;
                case 2:
                    foreach (var answ in currentQuiz.Questions[CounterQuiz].Answers)
                        stackPanel.Children.Add(new CheckBox()
                        {
                            Content = answ.Text,
                        });
                    //stackPanel.Children.Add(new ComboBox()
                    //{
                    //    ItemsSource = currentQuiz.Questions[CounterQuiz].Answers.Select(t => t.Text)
                    //});
                    break;
                default:
                    stackPanel.Children.Add(new TextBox());
                    break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CounterQuiz++;
            RefreshAnswerField();
        }
    }
}
