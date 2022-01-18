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
using System.Windows.Threading;

namespace Visual.View.Quiz.Form
{
    public partial class QuizWindow : Window
    {
        QuizzeDTO currentQuiz;
        Window _window;
        IQuizze quiz = Logic.Configuration.IocKernel.Get<IQuizze>();
        int CounterQuestion;
        string _currentQuestinsInfo;
        int CounterCorrectAnswers = 0;
        List<bool> isAnswered;
        bool flagAll = false;
        bool testTry;

        DispatcherTimer _timer;
        TimeSpan _time;
        //ctor
        public QuizWindow(Window window, long QuizID, bool TestTry = false)
        {
            InitializeComponent();
            testTry = TestTry;
            _window = window;
            currentQuiz = quiz.GetEntity(QuizID);
            CounterQuestion = 0;
            RefreshAnswerField();
            isAnswered = new List<bool>();
            for (var i = 0; i < currentQuiz.Questions.Count; i++)
                isAnswered.Add(false);

            _time = currentQuiz.TimeToComplete;

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                    ResultOutOFTime();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, 
            Application.Current.Dispatcher);

            _timer.Start();
        }
        public void RefreshAnswerField()
        {
            stackPanel.Children.Clear();
            _currentQuestinsInfo = $"Вопрос №{CounterQuestion + 1} из {currentQuiz.Questions.Count}"; // вытащить в отдельный метод
            QuestionInfoTextBlock.Text = _currentQuestinsInfo;                                    // вытащить в отдельный метод
            QuestionTextBlock.Text = currentQuiz.Questions[CounterQuestion].Text;
            SetAnswers();
        }
        private void SetAnswers()
        {
            switch (currentQuiz.Questions[CounterQuestion].ID_QuestType)
            {
                case 1:
                    foreach (var answ in currentQuiz.Questions[CounterQuestion].Answers)
                        stackPanel.Children.Add(new RadioButton()
                        {
                            Content = answ.Text,
                        });
                    break;
                case 2:
                    foreach (var answ in currentQuiz.Questions[CounterQuestion].Answers)
                        stackPanel.Children.Add(new CheckBox()
                        {
                            Content = answ.Text,
                        });
                    break;
                default:
                    stackPanel.Children.Add(new TextBox());
                    break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                CounterQuestion++;
                if (CounterQuestion == currentQuiz.Questions.Count)
                    CounterQuestion = 0;
            } while (isAnswered[CounterQuestion] && !flagAll);            
            RefreshAnswerField();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp;
            int tempCurrents;
            switch (currentQuiz.Questions[CounterQuestion].ID_QuestType)
            {
                case 1:
                    temp = 0;
                    foreach (RadioButton selvar in stackPanel.Children)
                    {
                        if (!selvar.IsChecked.Value)
                        {
                            temp++;
                            continue;
                        }
                        if (currentQuiz.Questions[CounterQuestion].Answers[temp].IsCorrect)
                        {
                            CounterCorrectAnswers++;
                            break;
                        }
                    }

                    break;
                case 2:
                    temp = 0;
                    tempCurrents = 0;
                    bool flag = false;
                    for (var i = 0; i < stackPanel.Children.Count; i++)
                        if ((stackPanel.Children[i] as CheckBox).IsChecked.Value)
                        {
                            if (currentQuiz.Questions[CounterQuestion].Answers[i].IsCorrect)
                                tempCurrents++;
                            else
                            {
                                flag = true;
                                break;
                            }
                        }                           

                    
                    //foreach (CheckBox selvar in stackPanel.Children)
                    //{
                    //    if (!selvar.IsChecked.Value)
                    //    {
                    //        temp++;
                    //        continue;
                    //    }
                    //    if (currentQuiz.Questions[CounterQuestion].Answers[temp].IsCorrect)
                    //    {
                    //        tempCurrents++;
                    //    }
                    //}
                    //int tmp = 0;
                    //foreach (var ans in currentQuiz.Questions[CounterQuestion].Answers)
                    //    if (ans.IsCorrect)
                    //        tmp++;
                    if (currentQuiz.Questions[CounterQuestion].Answers.Select(t => t.IsCorrect).Count(t => t) == tempCurrents && !flag)
                        CounterCorrectAnswers++;
                    break;
                default:
                    if ((stackPanel.Children[0] as TextBox).Text == currentQuiz.Questions[CounterQuestion].Answers.Single().Text)
                        CounterCorrectAnswers++;
                    break;
            }

            isAnswered[CounterQuestion] = true;
            flagAll = isAnswered.All(t => t);
            do
            {
                CounterQuestion++;
                if (CounterQuestion == currentQuiz.Questions.Count)
                    CounterQuestion = 0;
            } while (isAnswered[CounterQuestion] && !flagAll);
            if (CounterQuestion == 0)           
                Result();           
            else
                RefreshAnswerField();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {            
            do
            {
                CounterQuestion--;
                if (CounterQuestion == -1)
                    CounterQuestion = currentQuiz.Questions.Count - 1;
            } while (isAnswered[CounterQuestion]);
            RefreshAnswerField();
        }
        private void Result()
        {            
            _timer.Stop();
            new ResultWindow(_window, currentQuiz, currentQuiz.TimeToComplete - _time, CounterCorrectAnswers, testTry).Show();
            Close();
        }
        private void ResultOutOFTime()
        {
            if (MessageBox.Show("Открыть окно резултата?", "Время вышло!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Result();
            _window.Show();
            Close();
        }
    }
}
