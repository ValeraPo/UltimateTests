using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Visual.View.Quiz.Form
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        readonly Window    _window;
        readonly bool      _testTry;
        readonly QuizzeDTO _quizRes;
        readonly TimeSpan  _ts;
        readonly int       _score;
        readonly IUser     Ius = IocKernel.Get<IUser>();
        public ResultWindow(Window window, QuizzeDTO quizRes, TimeSpan ts, int score, bool testTry)
        {
            InitializeComponent();
            nameTextBlock.DataContext           = quizRes;
            currentScoreTextBlock.Text          = score.ToString();
            scoreTextBlock.DataContext          = quizRes;
            timeTextBlock.Text                  = $"{ts.Minutes} минут {ts.Seconds} секунд";
            timeToCompliteTextBlock.DataContext = quizRes;
            _testTry                            = testTry;
            _quizRes                            = quizRes;
            _ts                                 = ts;
            _score                              = score;
            _window                             = window;
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
            feedButton.IsEnabled   = false;
        }

        string GetStringFromTextBox(RichTextBox rtb) => new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
    }
}