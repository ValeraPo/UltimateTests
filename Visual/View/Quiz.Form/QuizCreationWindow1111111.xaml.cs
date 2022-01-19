using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for QuizCreationWindow.xaml
    /// </summary>
    public partial class QuizCreationWindow : Window
    {
        IQuizze                                    quiz   = Logic.Configuration.IocKernel.Get<IQuizze>();
        readonly ISetTag                           setTag = Logic.Configuration.IocKernel.Get<ISetTag>();
        QuizzeDTO                                  _currentQuiz;
        public   ObservableCollection<QuestionDTO> _newQuestions;
        readonly ObservableCollection<SetTagDTO>   _setTags;
        readonly ObservableCollection<SetTagDTO>   _currentTags;
        readonly List<AnswersType>                 _answersType;
        int                                        CountOfQuestions = 0;
        int                                        _quizTime        = 0;
        public QuizCreationWindow()
        {
            InitializeComponent();
            _newQuestions = new();
            _answersType = new();
            _currentTags = new();
            QuestionsListBox.ItemsSource = _newQuestions;

            _setTags = setTag.GetListEntity();
            TagsComboBox.ItemsSource = _setTags;
            TagsListBox.ItemsSource = _currentTags;
            SetDictionary(_answersType);
            QuestionsTypeComboBox.ItemsSource = _answersType;
        }
        private void SetDictionary(List<AnswersType> at)
        {
            at.Add(new AnswersType(1, "Один вариант ответа"));
            at.Add(new AnswersType(2, "Несколько вариантов ответа"));
            at.Add(new AnswersType(3, "Свободный ответ"));
        }
        public int QuizTime
        { get { return _quizTime; } 
          set { _quizTime = value; } }
        private void QuestionsButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //_newQuestions.Add(new QuestionDTO());
            

        }
        //Удалить вопрос из списка
        private void QuestionsButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsListBox.SelectedValue != null)
                _newQuestions.RemoveAt(QuestionsListBox.SelectedIndex);
        }

        private void QuizNameButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuizNameTextBox.IsEnabled)
                QuizNameTextBox.IsEnabled = false;
            else
                QuizNameTextBox.IsEnabled = true;
        }

        private void TagsButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var temp = (SetTagDTO)TagsComboBox.SelectedValue;

            if (!_currentTags.Contains(temp))
            {
                _currentTags.Add(temp);
            }
        }

        private void TagsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetTagDTO temp = (SetTagDTO)TagsListBox.SelectedValue;
            _currentTags.Remove(temp);
        }

        private void AnswersButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (((AnswersType)QuestionsTypeComboBox.SelectedItem) == null)
                return;
            StackPanel CorrectAnswersStackPanel = new StackPanel { Orientation = Orientation.Horizontal
            , HorizontalAlignment = HorizontalAlignment.Stretch
            , VerticalAlignment = VerticalAlignment.Stretch
            , 
            };
            switch (((AnswersType)QuestionsTypeComboBox.SelectedItem).TypeInt)
            {
                case 1:
                    CorrectAnswersStackPanel.Children.Add(new RadioButton { GroupName="radioGroup" });
                    CorrectAnswersStackPanel.Children.Add(new TextBox { Width = 200 });
                    break;
                case 2:
                    CorrectAnswersStackPanel.Children.Add(new CheckBox { });
                    CorrectAnswersStackPanel.Children.Add(new TextBox { Width = 200 });
                    break;
                default:
                    if (AnswersStackPanel.Children.Count != 0)
                        return;
                    AnswersStackPanel.Children.Add(new TextBox
                    {
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        AcceptsReturn = true,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Visible
                    }); ;
                    return;
            }
            AnswersStackPanel.Children.Add(CorrectAnswersStackPanel);
        }

        private void QuizNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (QuizNameTextBox.Text == "Название теста")
                QuizNameTextBox.Text = "";
        }

        private void QuizTimeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_quizTime == 0)
                QuizTimeTextBox.Text = "";
        }

        private void QuizTimeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (int.Parse(QuizTimeTextBox.Text))      //QuizTime <--- проверка на цифры
            QuizTime = int.Parse(QuizTimeTextBox.Text);
                QuizTimeTextBox.Text = $"{QuizTime} мин.";

        }

        private void TagsButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateTagTextBox.Visibility = Visibility.Hidden;
            TagsButtonCreate.Visibility = Visibility.Visible;
        }

        //private void QuestionsTypeComboBox_DropDownClosed(object sender, EventArgs e)
        //{
        //    if (((AnswersType)QuestionsTypeComboBox.SelectedItem).TypeInt)
                
        //}

        private void QuestionsTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnswersStackPanel.Children.Clear();
        }
    }
}
