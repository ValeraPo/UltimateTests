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
    /// Interaction logic for QuizCreationForm.xaml
    /// </summary>
    public partial class QuizCreationForm : Window
    {
        #region ctors
        //общий
        public QuizCreationForm()
        {
            InitializeComponent();
            quizNameTextBox.DataContext = _currentQuiz;

            _quizeListBox = new();
            QuizeListBox.ItemsSource = _quizeListBox;
            _tagsList = st.GetListEntity();
            _currentTags = new();
            tagsListBox.ItemsSource = _currentTags;
            timeChBox.IsChecked = false;
            SetDictionary(_answersType);
            typeQuestComboBox.ItemsSource = _answersType;
        }
        
        //изменение/назначение
        public QuizCreationForm(UserDTO curUser, QuizzeDTO selectedQuiz) : this()
        {
            
            _currentQuiz = selectedQuiz;
            foreach (var el in _currentQuiz.Questions)
            {
                int count = 1;
                _quizeListBox.Add($"Вопрос {count++}");
                createButt.Content = "Назначить";
            }
            _numOfQuestions = _quizeListBox.Count;
            _currentUser = curUser;
            typeQuestComboBox.ItemsSource = _quizeListBox;

            if (_currentUser.Type == 3)
            {
                teachersGrid.Visibility = Visibility.Visible;
                editStackPanel.IsEnabled = false;
                GroupComboBox.ItemsSource = userI.GetListGroupTeacher();
                createButt.Content = "Создать";

            }
            else
            {
                teachersGrid.Visibility = Visibility.Hidden;
                editStackPanel.IsEnabled = true;
            }
        }
        #endregion

        readonly UserDTO                         _currentUser;
        readonly ISetTag                         st    = Logic.Configuration.IocKernel.Get<ISetTag>();
        IQuizze                                  qui   = Logic.Configuration.IocKernel.Get<IQuizze>();
        readonly IUser                           userI = Logic.Configuration.IocKernel.Get<IUser>();
        readonly QuizzeDTO                       _currentQuiz;
        ObservableCollection<SetTagDTO>          _tagsList;
        public   ObservableCollection<string>    _quizeListBox { get; set; }
        readonly int                             _numOfQuestions;
        readonly ObservableCollection<SetTagDTO> _currentTags;
        private void SetDictionary(List<AnswersType> at)
        {
            at.Add(new AnswersType(1, "Один вариант ответа"));
            at.Add(new AnswersType(2, "Несколько вариантов ответа"));
            at.Add(new AnswersType(3, "Свободный ответ"));
        }
        List<AnswersType> _answersType;

        string _currentQuestName;                                                       // <- в создание вопроса
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!quizNameTextBox.IsEnabled)
                quizNameTextBox.IsEnabled = true;
            else
                quizNameTextBox.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _quizeListBox.Add($"Вопрос {_numOfQuestions}");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             //if (QuestionsListBox.SelectedValue != null)
             //   _newQuestions.RemoveAt(QuestionsListBox.SelectedIndex);
        }

        private void addTagButt_Click(object sender, RoutedEventArgs e)
        {
            if (creationsTag.Text != "")
                st.AddTeg(creationsTag.Text);
        }

        private void delTagButt_Click(object sender, RoutedEventArgs e)
        {
            if ((SetTagDTO)TagsComboBox.SelectedValue != null)
                st.RemoveTeg((SetTagDTO)TagsComboBox.SelectedValue);
        }

        private void TagsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var temp = (SetTagDTO)TagsComboBox.SelectedValue;

            if (!_currentTags.Contains(temp))
            {
                _currentTags.Add(temp);
            }
        }

        private void createButt_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Type == 3)
            {

                try
                {
                    // qui.AddAppointmentQuizze(QuizzeDTO quizze, (GroupDTO)GroupComboBox.SelectedValue, DateTime finishBefore);
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Все поля должны быть заполнены!");
                }
            }
            else
            {
                try
                {
                    
                    // qui.AddQuiz(QuizzeDTO quiz, _currentUser);
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Все поля должны быть заполнены!");
                }
            }
        }

        private void aplyButt_Click(object sender, RoutedEventArgs e)
        {
            if (GetStringFromTextBox(QuestionText).Length != 0)
                _currentQuestName = GetStringFromTextBox(QuestionText);
           
        }

        string GetStringFromTextBox(RichTextBox rtb) => new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;

        private void AnswersButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (((AnswersType)typeQuestComboBox.SelectedItem) == null)
                return;
            StackPanel CorrectAnswersStackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            ,
                HorizontalAlignment = HorizontalAlignment.Stretch
            ,
                VerticalAlignment = VerticalAlignment.Stretch
            ,
            };
            switch (((AnswersType)typeQuestComboBox.SelectedItem).TypeInt)
            {
                case 1:
                    CorrectAnswersStackPanel.Children.Add(new RadioButton { GroupName = "radioGroup" });
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
    }
}
