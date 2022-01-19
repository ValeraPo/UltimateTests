using Logic.Configuration;
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
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        Window _window;
        bool _testTry;
        QuizzeDTO _quizRes;
        TimeSpan _ts;
        int _score;
        IUser Ius = IocKernel.Get<IUser>();
        public ResultWindow(Window window, QuizzeDTO quizRes, TimeSpan ts, int score, bool testTry)
        {
            InitializeComponent();
            nameTextBlock.DataContext = quizRes;
            currentScoreTextBlock.Text = score.ToString();
            scoreTextBlock.DataContext = quizRes;
            timeTextBlock.Text = $"{ts.Minutes} минут {ts.Seconds} секунд";
            timeToCompliteTextBlock.DataContext = quizRes;
            _testTry = testTry;
            _quizRes = quizRes;
            _ts = ts;
            _score = score;
            _window = window;
            //timeToCompliteTextBlock = ts;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!_testTry) 
                Ius.AddAttempt(_quizRes, _score, _ts);
            _window.Show();
            Close();
        }

        private void feedButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetStringFromTextBox(feedBackText).Length != 0)
                Ius.AddFeedback(_quizRes, GetStringFromTextBox(feedBackText));
            feedBackText.IsEnabled = false;
            feedButton.IsEnabled = false;
        }

        string GetStringFromTextBox(RichTextBox rtb) => new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
    }
}
