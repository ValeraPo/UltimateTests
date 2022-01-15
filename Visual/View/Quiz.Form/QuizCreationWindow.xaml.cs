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
        IQuizze quiz = Logic.Configuration.IocKernel.Get<IQuizze>();
        ISetTag setTag = Logic.Configuration.IocKernel.Get<ISetTag>();
        QuizzeDTO _currentQuiz;
        ObservableCollection<string> _newQuestions;
        ObservableCollection<SetTagDTO> _setTags;
        ObservableCollection<SetTagDTO> _currentTags;
        List<AnswersType> _answersType;
        int CountOfQuestions = 0;
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
        private void QuestionsButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _newQuestions.Add($"Вопрос {_newQuestions.Count + 1}");
            CountOfQuestions++;
        }

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
            var temp = (SetTagDTO)TagsListBox.SelectedValue;
            _currentTags.Remove(temp);
        }

        private void AnswersButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            StackPanel CorrectAnswersStackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            switch (((AnswersType)QuestionsTypeComboBox.SelectedItem).TypeInt)
            {
                case 1:
                    CorrectAnswersStackPanel.Children.Add(new RadioButton { });
                    CorrectAnswersStackPanel.Children.Add(new TextBox { Width = 200 });
                    break;
                case 2:
                    CorrectAnswersStackPanel.Children.Add(new CheckBox { });
                    CorrectAnswersStackPanel.Children.Add(new TextBox { Width = 200  });
                    break;
                default:
                    CorrectAnswersStackPanel.Children.Add(new TextBox { Width = 200  });
                    break;

            }
            AnswersStackPanel.Children.Add(CorrectAnswersStackPanel);
        }
    }
}
